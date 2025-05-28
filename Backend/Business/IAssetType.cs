using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;
using Backend.Model.Dto;

namespace Backend.Business
{
    public interface IAssetType
    {
        Task<List<AssetType>> GetAllAsync();
        Task<AssetTypeRequestDto> CreateAsync(AssetTypeRequestDto assetTypeRequestDto);
        Task<AssetTypeRequestDto> UpdateAsync(Guid id,AssetTypeRequestDto assetTypeRequestDto);
        Task<AssetType> DeleteAsync(Guid id);
    }
}