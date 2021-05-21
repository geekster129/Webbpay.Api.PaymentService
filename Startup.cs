using System;
using System.Collections.Generic;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Webbpay.Api.PaymentService.Adapters.Database;
using Webbpay.Api.PaymentService.Adapters.UserProfile;
using Webbpay.Api.PaymentService.Helpers;

namespace Webbpay.Api.PaymentService
{
  public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        readonly string WebbpayPolicy = "WebbpayPolicy";
        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
              options.AddPolicy(name: WebbpayPolicy,
                                builder =>
                                {
                                  builder.WithOrigins(
                                      "https://localhost:44333",
                                      "https://localhost:5001"
                                      )
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                                });
            });


            services.AddControllers();

            services.AddHttpContextAccessor();
            services.AddTransient<IUserProfileAdapter, UserProfileAdapter>();
            services.AddTransient<AuthorizationMessageHandler>();

            services.AddDbContext<StoreDbContext>(options =>
              options.UseMySql(Configuration.GetConnectionString("PaymentLinkDb"), ServerVersion.Parse("8.0.20")),
              ServiceLifetime.Transient);

            services.AddHttpClient("UserProfile")
              .ConfigureHttpClient(http => http.BaseAddress = new Uri("https://api-userprofile.webbpay.io"))
              .AddHttpMessageHandler<AuthorizationMessageHandler>();

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://oauth.webbpay.io/connect/authorize"),
                            TokenUrl = new Uri("https://oauth.webbpay.io/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"webbpay.api", "Access to this api scope"},
                                {"openid", "Access to userId"},
                                {"profile", "Get profile details"}
                            }
                        }
                    }
                });
                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ValidApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "webbpay.api");
                });
            });

            services
                .AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "webbpay.api.store";
                    options.Authority = "https://oauth.webbpay.io";
                });
            services.AddMediatR(Assembly.GetExecutingAssembly());
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(WebbpayPolicy);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("");
                });
            });

            using var serviceScope = app.ApplicationServices
              .GetRequiredService<IServiceScopeFactory>()
              .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<StoreDbContext>();
            context.Database.Migrate();
            context.SaveChanges();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.OAuthClientId("swagger.auth");
                options.OAuthAppName("Swagger Auth");
                options.OAuthUsePkce();
            });
        }
    }
}
