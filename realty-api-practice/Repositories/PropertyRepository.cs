using Microsoft.EntityFrameworkCore;
using realty_api_practice.Entities.Common;
using realty_api_practice.Entities.Data;
using realty_api_practice.Repositories;

public class PropertyRepository : Repository<Property>, IPropertyRepository
{
    public PropertyRepository(ApplicationDbContext context) : base(context) { }

    public async Task<List<Property>> GetByCityAsync(string city)
        => await _dbSet
            .Include(p => p.PropertyType)
            .Where(p => p.City.Name == city && p.Active)
            .ToListAsync();

    public async Task<List<Property>> GetActiveAsync()
        => await _dbSet
            .Include(p => p.PropertyType)
            .Where(p => p.Active)
            .ToListAsync();

    public async Task<List<Property>> GetByTypeAsync(int propertyTypeId)
        => await _dbSet
            .Where(p => p.PropertyTypeId == propertyTypeId && p.Active)
            .ToListAsync();
}