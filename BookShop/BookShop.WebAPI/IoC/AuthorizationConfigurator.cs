﻿using BookShop.DataAccess;
using BookShop.DataAccess.Entities;
using BookShop.WebAPI.Settings;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BookShop.WebAPI.IoC
{
    public static class AuthorizationConfigurator
    {
        public static void ConfigureServices(this IServiceCollection services, BookShopSettings settings)
        {
            services.AddIdentity<CustomerEntity, CustomerRoleEntity>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
            })
                .AddEntityFrameworkStores<BookShopDbContext>()
                .AddSignInManager<SignInManager<CustomerEntity>>()
                .AddDefaultTokenProviders();

            _ = services.AddIdentityServer()
                .AddInMemoryApiScopes(new[] { new ApiScope("api") })
                .AddInMemoryClients(new[]
                {
                new Client()
                {
                    ClientName = settings.ClientId,
                    ClientSecrets = new List<Secret>()
                    {
                        new(settings.ClientSecret.Sha256())
                    },
                    AllowedScopes = new List<string>() { "api" }
                }
                })
                .AddAspNetIdentity<CustomerEntity>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = false;
                options.Authority = settings.IdentityServerUri;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                options.Audience = "api";
            });

            services.AddAuthorization();
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
