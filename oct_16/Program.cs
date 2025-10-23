
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Repositories;

namespace StudentApi
{
    public class Program
    {
        public static void Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Register DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();


            builder.Services.AddControllers();
            /*AddDbContext < AppDbContext > ? tells ASP.NET how to
            provide AppDbContext whenever a controller needs it*/
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
            //app.MapControllers();

            app.Run();
        }
    }
}
