using Microsoft.EntityFrameworkCore;
using Split.DbContexts;
using Split.Engine.Repositories;
using Split.Engine.Repositories.Interfaces;
using Split.Engine.Services;
using SplitWebService.Controllers;
using SplitWebService.Middleware;

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
            builder.Services.AddScoped<GroupService>();
            builder.Services.AddScoped<ExpenseSerivce>();
            builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            builder.Services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
            builder.Services.AddScoped(typeof(IGroupRepository), typeof(GroupRepository));
            builder.Services.AddScoped(typeof(IExpenseRepository), typeof(ExpenseRepository));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.UseAllOfToExtendReferenceSchemas();
            });

            builder.Services.AddDbContextFactory<SplitDbContext>(opt =>
            {
                //opt.UseMySql("Server=api.kiinse.me;Database=split;port=7223;User Id=root;password=TestPassword",
                opt.UseMySql(builder.Configuration.GetConnectionString("SplitConnection"),
                    new MySqlServerVersion(new Version(8, 0, 30)));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}