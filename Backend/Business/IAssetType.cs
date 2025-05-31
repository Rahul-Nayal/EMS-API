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
        Task<AssetTypeResponseDto> CreateAsync(AssetTypeResponseDto assetTypeResponseDto);
        Task<AssetTypeResponseDto> UpdateAsync(Guid id,AssetTypeResponseDto assetTypeResponseDto);
        Task<AssetType> DeleteAsync(Guid id);
    }
}