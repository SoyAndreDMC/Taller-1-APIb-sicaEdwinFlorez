using Employee.Backend.Data;
using Employee.Backend.Repositories.Implementations;
using Employee.Backend.Repositories.Interfaces;
using Employee.Backend.UnitsOfWork.Implementations;
using Employee.Backend.UnitsOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));
            builder.Services.AddTransient<SeedDb>();

            builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddScoped<IClerksRepository, ClerksRepository>();
            builder.Services.AddScoped<IClerksUnitOfWork, ClerksUnitOfWork>();

            var app = builder.Build();

            SeedData(app);

            void SeedData(WebApplication app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

                using var scope = scopedFactory!.CreateScope();
                var service = scope.ServiceProvider.GetService<SeedDb>();
                service!.SeedAsync().Wait();
            }
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