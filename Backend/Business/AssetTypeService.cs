using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class AssetTypeService : IAssetType
    {
        private readonly EMSDbContext eMSDbContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AssetTypeService(EMSDbContext eMSDbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.eMSDbContext = eMSDbContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<AssetType>> GetAllAsync()
        {
            var assetsType = await eMSDbContext.AssetTypes.ToListAsync();
            if (assetsType == null)
            {
                return null;
            }
            return assetsType;
        }

        public async Task<AssetTypeRequestDto> CreateAsync([FromForm]AssetTypeRequestDto assetTypeRequestDto)
        {
            var exisitingAssetType = await eMSDbContext.AssetTypes.FirstOrDefaultAsync(at => at.Name == assetTypeRequestDto.Name);
            if (exisitingAssetType != null)
            {
                return null;
            }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(assetTypeRequestDto.File.FileName);
            var filePath = Path.Combine("Images/AssetType", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await assetTypeRequestDto.File.CopyToAsync(stream);
            }
            var image = new Image
            {
                Id = Guid.NewGuid(),
                FileName = fileName,
                FileExtension = Path.GetExtension(assetTypeRequestDto.File.FileName),
                FileSizeInBytes = assetTypeRequestDto.File.Length,
                FilePath = $"Images/AssetType/{fileName}",
                FileDescription =  $"{httpContextAccessor.HttpContext.Request.Scheme}//{httpContextAccessor.HttpContext.Request.Host}//{httpContextAccessor.HttpContext.Request.PathBase}/Images/{fileName}{Path.GetExtension(assetTypeRequestDto.File.FileName)}",
            };

            await eMSDbContext.Images.AddAsync(image);

            var assetType = new AssetType
            {
                Id = Guid.NewGuid(),
                Name = assetTypeRequestDto.Name,
                Description = assetTypeRequestDto.Description,
                AssetImageUrl = image.Id
            };

            await eMSDbContext.AssetTypes.AddAsync(assetType);
            await eMSDbContext.SaveChangesAsync();
            return assetTypeRequestDto;
        }

        public async Task<AssetTypeRequestDto> UpdateAsync(Guid id, AssetTypeRequestDto assetTypeRequestDto)
        {
            var exisitingAssetType = await eMSDbContext.AssetTypes.FirstOrDefaultAsync(at=> at.Id == id);
            if (exisitingAssetType == null)
            {
                return null;
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(assetTypeRequestDto.File.FileName);
            var filePath = Path.Combine("Images/AssetType",fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await assetTypeRequestDto.File.CopyToAsync(stream);
            }
            ;

            var image = new Image
            {
                // Id = exisitingAssetType.AssetImageUrl.Value,
                FileName = fileName,
                FilePath = $"Images/AssetType/{fileName}",
                FileExtension = Path.GetExtension(assetTypeRequestDto.File.FileName),
                FileSizeInBytes = assetTypeRequestDto.File.Length,
                FileDescription = $"{httpContextAccessor.HttpContext.Request.Scheme}//{httpContextAccessor.HttpContext.Request.Host}//{httpContextAccessor.HttpContext.Request.PathBase}/Images/{fileName}/{Path.GetExtension(assetTypeRequestDto.File.FileName)}"
            };

            eMSDbContext.Images.Update(image);
            await eMSDbContext.SaveChangesAsync();
            exisitingAssetType.Name = assetTypeRequestDto.Name;
            exisitingAssetType.Description = assetTypeRequestDto.Description;
            exisitingAssetType.AssetImageUrl = image.Id;
            eMSDbContext.AssetTypes.Update(exisitingAssetType);
            await eMSDbContext.SaveChangesAsync();
            return assetTypeRequestDto;

        }

        public async Task<AssetType> DeleteAsync(Guid id)
        {
            var exisitingAssetType = await eMSDbContext.AssetTypes.FindAsync(id);
             if (exisitingAssetType != null)
                {
                    eMSDbContext.AssetTypes.Remove(exisitingAssetType);
                    await eMSDbContext.SaveChangesAsync();
                    return exisitingAssetType;
                };
            return null;
        }
    }
}