using Microsoft.EntityFrameworkCore;
using Spotlight.SignalR.DAL;
using Spotlight.SignalR.SignalR;

namespace Spotlight.SignalR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();

            // Configure Entity Framework Core to use SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
               
            //}

            app.UseHttpsRedirection();
            app.UseRouting(); 

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
                endpoints.MapHub<ChatHub>("/chathub"); 
            });

            app.Run();
        }
    }
}
