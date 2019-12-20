using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AspNetAbandondedCartTest.Api.ActionFilters;
using AspNetAbandondedCartTest.Configuration;
using AspNetAbandondedCartTest.Core;
using AspNetAbandondedCartTest.Core.Models;
using AspNetAbandondedCartTest.Core.Services;
using AspNetAbandondedCartTest.Data;
using AspNetAbandondedCartTest.Service;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace AspNetAbandondedCartTest.Api
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
            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddDbContext<DataContext>(x => 
            x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtSetting>(Configuration.GetSection("JwtSetting"));
            services.Configure<SendGridSetting>(Configuration.GetSection("SendGridSetting"));
            services.AddIdentity<Customer, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IHangfireRecurringJobService, HangfireRecurringJobService>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("JwtSetting:SecretKey").Value)),
                    
                };
            });

            services.AddSwaggerGen(opt =>
           {
               opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Asp.Net Abandond Cart Test", Version = "v1" });
               opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
               {
                   Description ="Jwt Authorization header scheme",
                   Name="Authorization",
                   In = ParameterLocation.Header,
                   Type = SecuritySchemeType.ApiKey
               });

               opt.AddSecurityRequirement(new OpenApiSecurityRequirement
               {
                   {new OpenApiSecurityScheme{ Reference = new OpenApiReference{
                       Id = "Bearer",
                       Type = ReferenceType.SecurityScheme
                   } }, 
                       new List<string>() }
               });

               var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
               opt.IncludeXmlComments(xmlPath);

           });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(opt =>
                {
                    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Asp.net Abandond Cart Test");
                    opt.RoutePrefix = string.Empty;
                });
            }
            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate<IHangfireRecurringJobService>(j => j.CheckForAbandonedCart(), Cron.Yearly);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
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
