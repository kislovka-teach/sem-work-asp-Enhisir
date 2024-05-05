using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Minio;

namespace Brah.Api.Extensions;

public static class ConfigurationExtension
{
    public static IServiceCollection AddJwtConfigured(this IServiceCollection services)
    {
        var config =
            services.BuildServiceProvider()
            .GetService<IConfiguration>()!;

        services.AddAuthentication(o =>
        {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = config["Jwt:Issuer"],
                ValidAudience = config["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(config["Jwt:Key"]!)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true
            };
        });

        return services;
    }

    public static IServiceCollection AddSwaggerConfigured(this IServiceCollection services)
    {
        return services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { 
                Title = "Brah", 
                Version = "v1" 
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                Type = SecuritySchemeType.Http,
                In = ParameterLocation.Header, 
                Description = "Добавьте JWT Bearer token в это поле",
                Name = "Authorization",
                Scheme = "bearer",
                BearerFormat = "JWT"
        
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { 
                    new OpenApiSecurityScheme 
                    { 
                        Reference = new OpenApiReference 
                        { 
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer" 
                        } 
                    },
                    Array.Empty<string>()
                } 
            });
        });
    }

    public static IServiceCollection AddMinioConfigured(this IServiceCollection services)
    {
        var config =
            services.BuildServiceProvider()
                .GetService<IConfiguration>()!;
       return services.AddMinio(configureClient => configureClient
            .WithEndpoint(config["Minio:Endpoint"])
            .WithCredentials(config["Minio:AccessKey"], config["Minio:SecretKey"])
            .WithSSL(false));
    }
}