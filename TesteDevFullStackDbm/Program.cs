using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TesteDevFullStackDbm.Data.Context;
using TesteDevFullStackDbm.Data.FluentMigrator;
using TesteDevFullStackDbm.Data.Repositories;
using TesteDevFullStackDbm.Interfaces.Repositories;
using TesteDevFullStackDbm.Interfaces.Services;
using TesteDevFullStackDbm.Services;

namespace TesteDevFullStackDbm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
               .AddSqlServer()
               .WithGlobalConnectionString(builder.Configuration.GetConnectionString("MyConnection"))
               .ScanIn(typeof(CreateClientTable).Assembly).For.Migrations()
            );

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddControllers();

            builder.Services.AddScoped<IServiceClient, ServiceClient>();
            builder.Services.AddScoped<IServiceProtocol, ServiceProtocol>();
            builder.Services.AddScoped<IRepositoryClient, RepositoryClient>();
            builder.Services.AddScoped<IRepositoryProtocol, RepositoryProtocol>();
            builder.Services.AddScoped<IRepositoryStatusProtocol, RepositoryStatusProtocol>();
            builder.Services.AddScoped<IRepositoryFollow, RepositoryFollow>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<MyContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"), sqlOptions => sqlOptions.CommandTimeout(120))
            );

            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                EnsureDatabaseExists(builder.Configuration.GetConnectionString("MyConnection"));
                runner.MigrateUp();
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Client}/{action=Index}/{id?}");

            app.Run();

            void EnsureDatabaseExists(string connectionString)
            {
                var databaseName = new SqlConnectionStringBuilder(connectionString).InitialCatalog;
                var masterConnectionString = connectionString.Replace(databaseName, "master");

                using var connection = new SqlConnection(masterConnectionString);
                using var command = new SqlCommand($"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{databaseName}') CREATE DATABASE [{databaseName}];", connection);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
