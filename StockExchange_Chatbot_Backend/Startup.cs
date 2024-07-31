using StockExchange_Chatbot_Backend.DataContext;
using StockExchange_Chatbot_Backend.ReadModel.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using StockExchange_Chatbot_Backend.Repositories;
using StockExchange_Chatbot_Backend.Commands;

namespace StockExchange_Chatbot_Backend
{
    public class Startup
    {
        public IConfiguration Configuration
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<StockDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Local")));

            // Add services to the container.
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddTransient<IValidator<RecordUserActivityCommand>, RecordUserActivityCommandValidator>();
            services.AddScoped<IStockRepository, StockRepository>();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {


            app.UseCors("AllowOrigin");

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod()
            );

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();


        }
    }
}