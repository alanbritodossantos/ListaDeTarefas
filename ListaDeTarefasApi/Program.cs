
using ListaDeTarefasApi.Data;
using ListaDeTarefasApi.Repositorios;
using ListaDeTarefasApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefasApi
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


            builder.Services.AddEntityFrameworkSqlServer()
       .AddDbContext<ListaDeTarefasContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        );

            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();

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