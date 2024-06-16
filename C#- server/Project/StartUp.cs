using DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Project.Controllers;
using Repository.Interface;
using Repository;
//using Repository.Interfaces;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Project
{
    public class StartUp
    {
        private string policy = "policy";

        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
            //policy = Configuration.GetSection("CorsSettings")["PolicyName"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //מחלקה חתומה sealed=שאי אפשר לרשת אותה
            //extension method-שיטות להרחבה 
            //ניתן להוסיף פונקציות למחלקה חתומה 
            //1/פונקציה סטטית
            //2במחלקה סטטית  
            //3 מצביע למחלקה

            services.AddControllers();
            services.AddService();
            services.AddDbContext<IContext, Db>();
            //הגדרת התלויות
            //builder.services.
            // services.AddScoped<IRepository<Product>, ProductRepository>();
            //addScopded עבור כל גולש יצור הזרקת תלות 
            //services.AddTransient-עבור כל בקשה 
            //services.AddSingleton-עבור כל הגולשים
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                  .AddJwtBearer(option =>
                  option.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = Configuration["Jwt:Issuer"],
                      ValidAudience = Configuration["Jwt:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))

                  });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project", Version = "v1" });
            });
            //  services.
            services.AddCors(options =>
            {
                options.AddPolicy(name: policy, policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthorization();

            app.UseCors(policy);
            //אימות משתמשים
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
