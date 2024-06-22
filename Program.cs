
using FirstProj.Models;
using FirstProj.Servises;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace FirstProj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors();
            builder.Services.AddDbContext<Dbconmovi>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddTransient<IGenerServise,GenresServises>();
            builder.Services.AddTransient<IMoviesServies,MoviesServies>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TestApi",
                    Description = "My First Project",
                    TermsOfService = new Uri("https://github.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Ahmed",
                        Email = "wael97343@gmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "My License",
                        Url = new Uri("https://github.com")
                    }
                });

                options.AddSecurityDefinition("dell", new OpenApiSecurityScheme
                {
                    Name="Authorization",
                    Type=SecuritySchemeType.ApiKey,
                    Scheme="dell",
                    BearerFormat="JWT",
                    In=ParameterLocation.Header,
                    Description="enter jwt key" });

            });
            builder.Services.AddAutoMapper(typeof(Program));
        
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(c=>c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.MapControllers();

            app.Run();
        }
    }
}