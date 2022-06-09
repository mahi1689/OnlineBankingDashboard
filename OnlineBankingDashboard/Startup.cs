using Microsoft.EntityFrameworkCore;
using OnlineBankingDashboard.Models;

namespace OnlineBankingDashboard
{
    public class Startup
    {
        public static WebApplication InitializeApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }



        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            _ = builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                });
            });

            


            builder.Services.AddDbContext<ChangerUserIdPwdContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection")));
            builder.Services.AddDbContext<Applicationcontext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection")));



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();



            //builder.Services.AddDistributedMemoryCache();

            //builder.Services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //});

            //builder.Services.AddHttpContextAccessor();
            //builder.Services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromMinutes(10);
            //    //options.Cookie.HttpOnly = true;
            //    //options.Cookie.IsEssential = true;
            //});



        }

        public static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();


           // app.UseSession();
            app.MapControllers();

            

            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
            });

        }
    }
}
