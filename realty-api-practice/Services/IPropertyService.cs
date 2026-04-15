using realty_api_practice.DTOs;
using realty_api_practice.DTOs.Property;

namespace realty_api_practice.Services
{
    public class IPropertyService
    {
        //The CONTRACT   - the controller depends on this interfasce , no thte concrete class
        //Why ? so you can swap the real service for a fake on in test without changing a sinmgle line in the controller

        public interface IPropertyService
        {
            Task<ApiResponse<List<PropertyResponseDto>>> GetAllAsync();
            Task<ApiResponse<PropertyResponseDto>> GetByIdAsync(int id);

        }
    }
}
