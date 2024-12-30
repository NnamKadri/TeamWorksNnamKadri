
using Infrastructure.Data;
using Infrastructure.Repository.IRepository;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using NewsPostApp.Extensions;

namespace NewsPostApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
			var config = builder.Configuration;
			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
	                    builder.Configuration.GetConnectionString("DefaultConnection")));
			builder.Services.RegisterServices(config);

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
