using Microsoft.EntityFrameworkCore;
using tour_api.Interfaces;
using tour_api.Models;
using tour_api.Repositories;
using Microsoft.OpenApi.Models;

namespace tour_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IConnectionRepository, ConnectionRepository>();
            builder.Services.AddScoped<ITourRepository, TourRepository>();
            builder.Services.AddScoped<ITourTypesRepository, TourTypesRepository>();
            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();

            builder.Services.AddDbContext<_43pToursContext>(options =>
            {
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString(
                        //"DatabaseNGK"
                        "DatabaseHome"
                        )
                    );
            });

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo()
                    {
                        Version = "v1",
                        Title = "Tour Web API",
                        Description = "First versshio API for progect that managment tours"
                    }
                    );
                }
            );

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
