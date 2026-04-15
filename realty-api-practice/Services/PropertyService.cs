using realty_api_practice.DTOs;
using realty_api_practice.DTOs.Property;
using realty_api_practice.Entities.Common;
using realty_api_practice.Repositories;

namespace realty_api_practice.Services
{
    // This is the BUSINESS LOGIC layer.
    // Controller calls this → this calls the repository → repository talks to DB
    // Rule: nothing in here touches HttpContext. Nothing in the controller touches the DB.
    public class PropertyService : IPropertyService
    {

        // Depends on the INTERFACE, not the concrete class.
        // .NET Dependency Injection hands us the right implementation at runtime.
        private readonly IPropertyRepository _repo;

        public PropertyService(IPropertyRepository repo)
        {
            _repo = repo;
        }

        // ── GET ALL ACTIVE ─────────────────────────────────────────────────
        public async Task<ApiResponse<List<PropertyResponseDto>>> GetAllAsync()
        {
            // GetActiveAsync() is YOUR method in PropertyRepository
            // It already filters WHERE Active = true
            var properties = await _repo.GetActiveAsync();

            // .Select(MapToDto) runs our private mapper on each entity
            // result: List<Entity> → List<DTO>
            var dtos = properties.Select(MapToDto).ToList();

            return ApiResponse<List<PropertyResponseDto>>.Ok(dtos);
        }

        // ── GET BY ID ──────────────────────────────────────────────────────
        public async Task<ApiResponse<PropertyResponseDto>> GetByIdAsync(int id)
        {
            var property = await _repo.GetByIdAsync(id);

            // Controlled failure — returns clean JSON, not a 500 crash
            if (property == null)
                return ApiResponse<PropertyResponseDto>.Fail($"Property with id {id} not found.");

            return ApiResponse<PropertyResponseDto>.Ok(MapToDto(property));
        }

        // ── GET BY CITY ────────────────────────────────────────────────────
        public async Task<ApiResponse<List<PropertyResponseDto>>> GetByCityAsync(string city)
        {
            // GetByCityAsync() is YOUR method in PropertyRepository
            var properties = await _repo.GetByCityAsync(city);

            if (!properties.Any())
                return ApiResponse<List<PropertyResponseDto>>.Fail($"No properties found in {city}.");

            return ApiResponse<List<PropertyResponseDto>>.Ok(properties.Select(MapToDto).ToList());
        }

        // ── GET BY TYPE ────────────────────────────────────────────────────
        public async Task<ApiResponse<List<PropertyResponseDto>>> GetByTypeAsync(int typeId)
        {
            // GetByTypeAsync() is YOUR method in PropertyRepository
            var properties = await _repo.GetByTypeAsync(typeId);

            if (!properties.Any())
                return ApiResponse<List<PropertyResponseDto>>.Fail($"No properties found for type {typeId}.");

            return ApiResponse<List<PropertyResponseDto>>.Ok(properties.Select(MapToDto).ToList());
        }

        // ── CREATE ─────────────────────────────────────────────────────────
        public async Task<ApiResponse<PropertyResponseDto>> CreateAsync(PropertyCreateDto dto)
        {
            // Business rule validation — happens BEFORE touching the DB
            if (dto.Price <= 0)
                return ApiResponse<PropertyResponseDto>.Fail("Price must be greater than zero.");

            if (string.IsNullOrWhiteSpace(dto.Title))
                return ApiResponse<PropertyResponseDto>.Fail("Title is required.");

            // Map DTO → Entity
            // This happens in the service, NEVER in the controller
            var entity = new Property
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                Bedrooms = dto.Bedrooms,
                Bathrooms = dto.Bathrooms,
                Address = dto.Address,
                CityId = dto.CityId,
                SquareFeet = dto.SquareFeet,
                LotSize = dto.LotSize,
                YearBuilt = dto.YearBuilt,
                ParkingSpaces = dto.ParkingSpaces,
                HOAFees = dto.HOAFees,
                PropertyTypeId = dto.PropertyTypeId,
                LegalStatusId = dto.LegalStatusId,
                ListingSourceId = dto.ListingSourceId,
                CreatedOn = DateTime.UtcNow,  // server sets this, never the client
                Active = true
            };

            // Repository handles the actual INSERT + SaveChangesAsync
            var created = await _repo.AddAsync(entity);

            return ApiResponse<PropertyResponseDto>.Ok(MapToDto(created), "Property created successfully.");
        }

        // ── UPDATE ─────────────────────────────────────────────────────────
        public async Task<ApiResponse<PropertyResponseDto>> UpdateAsync(int id, PropertyCreateDto dto)
        {
            // Always check existence first — fail early, fail clearly
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return ApiResponse<PropertyResponseDto>.Fail($"Property with id {id} not found.");

            // Only update fields the client is allowed to change
            // CreatedOn and Active are intentionally excluded — client cannot touch these
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Price = dto.Price;
            entity.Bedrooms = dto.Bedrooms;
            entity.Bathrooms = dto.Bathrooms;
            entity.Address = dto.Address;
            entity.CityId = dto.CityId;
            entity.SquareFeet = dto.SquareFeet;
            entity.LotSize = dto.LotSize;
            entity.YearBuilt = dto.YearBuilt;
            entity.ParkingSpaces = dto.ParkingSpaces;
            entity.HOAFees = dto.HOAFees;
            entity.PropertyTypeId = dto.PropertyTypeId;
            entity.LegalStatusId = dto.LegalStatusId;
            entity.ListingSourceId = dto.ListingSourceId;

            await _repo.UpdateAsync(entity);

            return ApiResponse<PropertyResponseDto>.Ok(MapToDto(entity), "Property updated successfully.");
        }

        // ── DELETE ─────────────────────────────────────────────────────────
        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return ApiResponse<bool>.Fail($"Property with id {id} not found.");

            await _repo.DeleteAsync(id);

            return ApiResponse<bool>.Ok(true, "Property deleted successfully.");
        }

        // ── PRIVATE MAPPER ─────────────────────────────────────────────────
        // Entity → DTO conversion.
        // Private: nothing outside this service should map.
        // Static: doesn't need any instance data, so no reason to allocate one.
        // ?.  means null-safe — if the navigation property wasn't .Include()'d, 
        // we get empty string instead of a NullReferenceException crash.
        private static PropertyResponseDto MapToDto(Property p) => new()
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            Price = (int)p.Price,       // your ResponseDto uses int Price
            Bedrooms = p.Bedrooms,
            Bathrooms = p.Bathrooms,
            Address = p.Address,
            YearBuilt = p.YearBuilt,
            SquareFeet = p.SquareFeet,
            LotSize = p.LotSize,
            ParkingSpaces = p.ParkingSpaces,
            HOAFees = p.HOAFees,
            Active = p.Active,
            CreatedOn = p.CreatedOn,
            CityId = p.CityId,
            CityName = p.City?.Name ?? string.Empty,
            PropertyTypeId = p.PropertyTypeId,
            LegalStatusName = p.LegalStatus?.Name ?? string.Empty,
            ListingSourceId = p.ListingSourceId,
            ListingSourceName = p.ListingSource?.Name ?? string.Empty,
            // Flattens the Images collection down to just the URL strings
            ImageUrls = p.Images?.Select(i => i.ImageUrl).ToList() ?? new()
        };
    }
}