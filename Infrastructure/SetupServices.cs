using Domain.AggregatesModel.ContactAggregate;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class SetupServices
{
     public static void SetupRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TriadRealEstateMediaContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), c => c.UseNetTopologySuite()));
        
        services.AddTransient<IContactRepository, ContactRepository>();
    }
    
    public static void UseInfrastructure(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        scope.ServiceProvider.GetRequiredService<TriadRealEstateMediaContext>().Database.Migrate();
    }
}