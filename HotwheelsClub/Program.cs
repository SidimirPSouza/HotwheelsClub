using HotwheelsClub.Data;
using HotwheelsClub.Repository;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service;
using HotwheelsClub.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotwheelsClub
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

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<HotwheelsClubDBContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
                );
            builder.Services.AddDbContext<DbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

            builder.Services.AddScoped<IHotwheelsRepository, HotwheelsRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IHotwheelsService, HotwheelsService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IClubRepository, ClubRepository>();
            builder.Services.AddScoped<IClubService, ClubService>();
            builder.Services.AddScoped<ITransferService, TransferService>();
            

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
