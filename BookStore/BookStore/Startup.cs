using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RepoLayer.Context;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NLog.Web;
using NLog.Extensions.Logging;
using System.Diagnostics;

namespace BookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Database Configuration
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BookStoreDBConnection")));

            services.AddControllers();

            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IUserRepo, UserRepo>();

            services.AddScoped<IBookBusiness, BookBusiness>();
            services.AddScoped<IBookRepo, BookRepo>();

            services.AddScoped<IOrderBusiness, OrderBusiness>();
            services.AddScoped<IOrderRepo, OrderRepo>();

            services.AddScoped<IAddressBusiness, AddressBusiness>();
            services.AddScoped<IAddressRepo, AddressRepo>();

            //Swagger Configuration
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Book Store",
                    Version = "1.0",
                    Description = "Book Store Api",
                    TermsOfService = new Uri("https://swagger.io/specification/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Upendra Sahu",
                        Email = "upendrasahu1199@gmail.com",
                        Url = new Uri("https://twitter.com/UPENDRA79252805"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Upendra Sahu",
                        Url = new Uri("https://github.com/Upendrasahu99"),
                    },
                });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",//Jwt format is Bearer
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http,
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                         new List<string>() // Empty list String not require any specific scopes for access. The user only needs to provide a valid JWT token (Bearer authentication).
                    },
                });
            });

            //Jwt Configuration
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSetting:SecretKey"]))
                    };
                });

            //Logging Provider and Nlog Configuration
            services.AddLogging(config =>
            {
                config.ClearProviders();
                config.AddConsole();
                //Unable NLog as one of the logging provider
                config.AddNLog();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "1,0");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
