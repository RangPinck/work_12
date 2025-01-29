
using Microsoft.EntityFrameworkCore;
using tour_api.Interfaces;
using tour_api.Models;
using tour_api.Repositories;

namespace tour_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IConnectionRepository, ConnectionRepository>();

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
            builder.Services.AddSwaggerGen();

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
