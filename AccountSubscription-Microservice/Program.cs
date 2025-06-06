using DittoBox.API.AccountSubscription.Application.Handlers.Interfaces;
using DittoBox.API.AccountSubscription.Application.Handlers.Internal;
using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Services;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using DittoBox.API.AccountSubscription.Domain.Services.Application;
using DittoBox.API.AccountSubscription.Infrastructure.Repositories;
using DittoBox.API.Shared.Domain.Repositories;
using DittoBox.API.Shared.Infrastructure;
using DittoBox.API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.API
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
            builder.Configuration.AddUserSecrets<Program>();

            var postgresConnectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");

            if (string.IsNullOrEmpty(postgresConnectionString))
            {
                postgresConnectionString = builder.Configuration.GetConnectionString("POSTGRES_CONNECTION_STRING");
            }
            if (string.IsNullOrEmpty(postgresConnectionString))
            {
                throw new ArgumentException("PostgreSQL connection string is not configured.");
            }

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(
                    postgresConnectionString
                )
            );

            builder.Services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            RegisterHandlers(builder);
            RegisterRepositories(builder);
            RegisterServices(builder);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();


            // Reset database
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (Environment.GetEnvironmentVariable("RESET_DATABASE") == "true") {
                  db.Database.EnsureDeleted();
                }
                db.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        public static void RegisterHandlers(WebApplicationBuilder builder)
        {
            /* UserProfile handlers */
            builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", corsPolicyBuilder =>
                            {
                corsPolicyBuilder.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader();
            });
    }); 

            /* AccountSubscription handlers */
            builder.Services.AddScoped<IDeleteAccountCommandHandler, DeleteAccountCommandHandler>();
            builder.Services.AddScoped<IGetAccountDetailsQueryHandler, GetAccountDetailsQueryHandler>();
            builder.Services.AddScoped<IUpdateAccountCommandHandler, UpdateAccountCommandHandler>();
            builder.Services.AddScoped<IUpdateBusinessInformationCommandHandler, UpdateBusinessInformationCommandHandler>();
            builder.Services.AddScoped<ICancelSubscriptionCommandHandler, CancelSubscriptionCommandHandler>();
            builder.Services.AddScoped<IDowngradeSubscriptionCommandHandler, DowngradeSubscriptionCommandHandler>();
            builder.Services.AddScoped<IUpgradeSubscriptionCommandHandler, UpgradeSubscriptionCommandHandler>();
            builder.Services.AddScoped<IGetSubscriptionDetailsQueryHandler, GetSubscriptionDetailsQueryHandler>();
            builder.Services.AddScoped<ICancelSubscriptionCommandHandler, CancelSubscriptionCommandHandler>();

        }

        public static void RegisterRepositories(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

        }

        public static void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
        }
    }
}
