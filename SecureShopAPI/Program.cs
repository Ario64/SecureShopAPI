using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SecureShopAPI.Mapping.Profiles;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SecureShopAPI.Data;
using SecureShopAPI.Repositories;
using SecureShopAPI.Services;
using SecureShopAPI.UnitOfWorkService;

namespace SecureShopAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region DB Context

            builder.Services.AddDbContext<SecureShopContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SecureShopConnectionString"));
            });

            #endregion

            #region IoC

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
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
