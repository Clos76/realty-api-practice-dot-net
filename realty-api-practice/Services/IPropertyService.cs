using realty_api_practice.DTOs;
using realty_api_practice.DTOs.Property;
using realty_api_practice.Services;

namespace realty_api_practice.Services
{
    public interface IPropertyService
    {
        //The CONTRACT   - the controller depends on this interfasce , no thte concrete class
        //Why ? so you can swap the real service for a fake on in test without changing a sinmgle line in the controller

       
            Task<ApiResponse<List<PropertyResponseDto>>> GetAllAsync();
            Task<ApiResponse<PropertyResponseDto>> GetByIdAsync(int id);
            Task<ApiResponse<List<PropertyResponseDto>>> GetByCityAsync(string city);
            Task<ApiResponse<List<PropertyResponseDto>>> GetByTypeAsync(int typeId);
        Task<ApiResponse<PropertyResponseDto>> CreateAsync(PropertyCreateDto dto);
          Task<ApiResponse<PropertyResponseDto>> UpdateAsync(int id, PropertyCreateDto dto);

    }
}
