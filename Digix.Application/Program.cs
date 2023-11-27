
using Digix.Application.Repositories;
using Digix.Application.Services;
using Digix.Data;
using Digix.Domain.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Digix.Application
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

            builder.Services.AddDbContext<DataContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.AddScoped<IFamilyRepository, FamilyRepository>();

            builder.Services.AddScoped<IFamilyService, FamilyService>();

            // Add Rula handlers
            builder.Services.AddSingleton<FirstRuleHandler>();
            builder.Services.AddSingleton<SecondRuleHandler>();
            builder.Services.AddSingleton<ThirdRuleHandler>();
            builder.Services.AddSingleton<FourthRuleHandler>();
            builder.Services.AddSingleton<HandlerRules>();
            
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