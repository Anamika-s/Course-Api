using CourseApi.Context;
using CourseApi.IRepo;
using CourseApi.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CourseApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // register the class on which controller is dependent on
            // providing its lifetime
            // AddScoped  > one instance will be there for one session
            // AddSingleton >one instance for all requests , logging  
            // AddTransient >> one instance for every request, transactions
            builder.Services.AddScoped<ICourseRepo,CourseRepo>();
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = builder.Configuration["Jwt:Issuer"],
              ValidAudience = builder.Configuration["Jwt:Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
          };
      });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRoleOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("RequireManagerAndAdmin", policy => policy.RequireRole("Admin", "Manager"));
            });
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("*");
                    builder.WithMethods("*");
                    builder.AllowAnyHeader();
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.

           
            app.UseHttpsRedirection();

            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
