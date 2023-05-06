
using Microsoft.EntityFrameworkCore;
using Split.DbContexts;
using Split.Engine.Repositories;
using Split.Engine.Repositories.Interfaces;
using Split.Engine.Services;
using SplitWebService.Controllers;

namespace SplitWebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<RoleService>();
            builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            builder.Services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContextFactory<SplitDbContext>(opt =>
            {
                //TODO: Брать connectionstring из файла
                opt.UseMySql("Server=127.0.0.1;Database=split;port=3306;User Id=root;password=Olegka_2003",
                    new MySqlServerVersion(new Version(8, 0, 30)));
            });

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