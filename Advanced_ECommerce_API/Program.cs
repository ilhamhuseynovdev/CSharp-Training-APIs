
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Advanced_ECommerce_API.Data;
using System.Reflection;
using Advanced_ECommerce_API.Services.Interfaces;
using Advanced_ECommerce_API.Services;

namespace Advanced_ECommerce_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Services.AddDbContext<AppDbContext>(opt=>
            opt.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                );

            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
