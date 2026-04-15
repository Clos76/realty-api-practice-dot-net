using realty_api_practice.Entities.Common;

namespace realty_api_practice.Repositories
{
    public interface IPropertyRepository : IRepository<Property>
    {
        Task<List<Property>> GetByCityAsync(string city);
        Task<List<Property>> GetActiveAsync();
        Task<List<Property>> GetByTypeAsync(int propertyTypeId);
    }
}