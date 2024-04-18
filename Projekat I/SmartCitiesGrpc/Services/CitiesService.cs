using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Grpc.Core;
using Grpc.Net;
using SmartCitiesGrpc; 

public class CitiesService : SmartCitiesService.SmartCitiesServiceBase
{
    private readonly SmartCitiesDbContext _dbContext;

    public CitiesService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<SmartCitiesDbContext>()
            .UseMySQL(connectionString); 

        _dbContext = new SmartCitiesDbContext(optionsBuilder.Options);
    }

    public override async Task<City> GetCity(CityId request, ServerCallContext context)
    {
        var cityFromDb = await _dbContext.smartcities.FindAsync(request.Id);
        
        if (cityFromDb == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "Grad nije pronađen."));
        }

        return await Task.FromResult(new City
        {
            Id = cityFromDb.Id,
            City_ = cityFromDb.City,
            Country = cityFromDb.Country,
            SmartMobility = cityFromDb.SmartMobility,
            SmartEnvironment = cityFromDb.SmartEnvironment,
            SmartGovernment = cityFromDb.SmartGovernment,
            SmartEconomy = cityFromDb.SmartEconomy,
            SmartPeople = cityFromDb.SmartPeople,
            SmartLiving = cityFromDb.SmartLiving,
            SmartcityIndex = cityFromDb.SmartCityIndex,
            SmartcityIndexRelativeEdmonton = cityFromDb.SmartCityIndexRelativeEdmonton
        });
    }

     public override async Task<CityList> GetAllCities(Empty request, ServerCallContext context)
    {
        var citiesFromDb = await _dbContext.smartcities.ToListAsync();

        var cityList = new CityList();
        cityList.Cities.AddRange(citiesFromDb.Select(cityFromDb => new City
        {
            Id = cityFromDb.Id,
            City_ = cityFromDb.City,
            Country = cityFromDb.Country,
            SmartMobility = cityFromDb.SmartMobility,
            SmartEnvironment = cityFromDb.SmartEnvironment,
            SmartGovernment = cityFromDb.SmartGovernment,
            SmartEconomy = cityFromDb.SmartEconomy,
            SmartPeople = cityFromDb.SmartPeople,
            SmartLiving = cityFromDb.SmartLiving,
            SmartcityIndex = cityFromDb.SmartCityIndex,
            SmartcityIndexRelativeEdmonton = cityFromDb.SmartCityIndexRelativeEdmonton
        }));

        return await Task.FromResult(cityList);
    }

    public override async Task<CityId> AddCity(City request, ServerCallContext context)
    {
    var cityEntity = new CityValue
    {
        City = request.City_,
        Country = request.Country,
        SmartMobility = request.SmartMobility,
        SmartEnvironment = request.SmartEnvironment,
        SmartGovernment = request.SmartGovernment,
        SmartEconomy = request.SmartEconomy,
        SmartPeople = request.SmartPeople,
        SmartLiving = request.SmartLiving,
        SmartCityIndex = request.SmartcityIndex,
        SmartCityIndexRelativeEdmonton = request.SmartcityIndexRelativeEdmonton
    };

    _dbContext.smartcities.Add(cityEntity);
    await _dbContext.SaveChangesAsync();

    
    return await Task.FromResult(new CityId { Id = cityEntity.Id });
    }

    public override async Task<City> UpdateCity(City request, ServerCallContext context)
    {
        var cityEntity = await _dbContext.smartcities.FindAsync(request.Id);
    if (cityEntity == null)
    {
        throw new RpcException(new Status(StatusCode.NotFound, "Grad nije pronađen."));
    }

    cityEntity.City = request.City_;
    cityEntity.Country = request.Country;
    cityEntity.SmartMobility = request.SmartMobility;
    cityEntity.SmartEnvironment = request.SmartEnvironment;
    cityEntity.SmartGovernment = request.SmartGovernment;
    cityEntity.SmartEconomy = request.SmartEconomy;
    cityEntity.SmartPeople = request.SmartPeople;
    cityEntity.SmartLiving = request.SmartLiving;
    cityEntity.SmartCityIndex = request.SmartcityIndex;
    cityEntity.SmartCityIndexRelativeEdmonton = request.SmartcityIndexRelativeEdmonton;

    await _dbContext.SaveChangesAsync();

    return await Task.FromResult(new City
    {
        Id = cityEntity.Id,
        City_ = cityEntity.City,
        Country = cityEntity.Country,
        SmartMobility = cityEntity.SmartMobility,
        SmartEnvironment = cityEntity.SmartEnvironment,
        SmartGovernment = cityEntity.SmartGovernment,
        SmartEconomy = cityEntity.SmartEconomy,
        SmartPeople = cityEntity.SmartPeople,
        SmartLiving = cityEntity.SmartLiving,
        SmartcityIndex = cityEntity.SmartCityIndex,
        SmartcityIndexRelativeEdmonton = cityEntity.SmartCityIndexRelativeEdmonton
    });
    }

    public override async Task<Empty> DeleteCity(CityId request, ServerCallContext context)
    {
        var cityEntity = await _dbContext.smartcities.FindAsync(request.Id);
        if (cityEntity == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "Grad nije pronađen."));
        }

        _dbContext.smartcities.Remove(cityEntity);
        await _dbContext.SaveChangesAsync();

        return await Task.FromResult(new Empty());
    }

     public override async Task<SmartStats> GetSmartMobilityStats(Empty request, ServerCallContext context)
    {
        var stats = await _dbContext.smartcities
            .Select(c => c.SmartMobility)
            .ToListAsync();

        return await Task.FromResult(new SmartStats
        {
            Min = stats.Min(),
            Max = stats.Max(),
            Avg = stats.Average(),
            Sum = stats.Sum()
        });
    }

     public override async Task<SmartStats> GetSmartEnvironmentStats(Empty request, ServerCallContext context)
    {
        var stats = await _dbContext.smartcities
            .Select(c => c.SmartEnvironment)
            .ToListAsync();

        return await Task.FromResult(new SmartStats
        {
            Min = stats.Min(),
            Max = stats.Max(),
            Avg = stats.Average(),
            Sum = stats.Sum()
        });
    }

     public override async Task<SmartStats> GetSmartGovernmentStats(Empty request, ServerCallContext context)
    {
        var stats = await _dbContext.smartcities
            .Select(c => c.SmartGovernment)
            .ToListAsync();

        return await Task.FromResult(new SmartStats
        {
            Min = stats.Min(),
            Max = stats.Max(),
            Avg = stats.Average(),
            Sum = stats.Sum()
        });
    }

     public override async Task<SmartStats> GetSmartEconomyStats(Empty request, ServerCallContext context)
    {
        var stats = await _dbContext.smartcities
            .Select(c => c.SmartEconomy)
            .ToListAsync();

        return await Task.FromResult(new SmartStats
        {
            Min = stats.Min(),
            Max = stats.Max(),
            Avg = stats.Average(),
            Sum = stats.Sum()
        });
    }

     public override async Task<SmartStats> GetSmartPeopleStats(Empty request, ServerCallContext context)
    {
        var stats = await _dbContext.smartcities
            .Select(c => c.SmartPeople)
            .ToListAsync();

        return await Task.FromResult(new SmartStats
        {
            Min = stats.Min(),
            Max = stats.Max(),
            Avg = stats.Average(),
            Sum = stats.Sum()
        });
    }

      public override async Task<SmartStats> GetSmartLivingStats(Empty request, ServerCallContext context)
    {
        var stats = await _dbContext.smartcities
            .Select(c => c.SmartLiving)
            .ToListAsync();

        return await Task.FromResult(new SmartStats
        {
            Min = stats.Min(),
            Max = stats.Max(),
            Avg = stats.Average(),
            Sum = stats.Sum()
        });
    }

     public override async Task<SmartStats> GetSmartCityIndexStats(Empty request, ServerCallContext context)
    {
        var stats = await _dbContext.smartcities
            .Select(c => c.SmartCityIndex)
            .ToListAsync();

        return await Task.FromResult(new SmartStats
        {
            Min = stats.Min(),
            Max = stats.Max(),
            Avg = stats.Average(),
            Sum = stats.Sum()
        });
    }
}



