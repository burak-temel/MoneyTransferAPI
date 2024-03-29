﻿using Microsoft.EntityFrameworkCore;
using MoneyTransferAPI.DataAccess;
using MoneyTransferAPI.Infrastructure.DependencyInjection;
using MoneyTransferAPI.RepositoryInterface;

namespace MoneyTransferAPI.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Bu metod çalışma zamanında çağrılır. Servisleri burada kaydedin.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options =>
                      options.UseNpgsql
                      (Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);
        }

        // Bu metod çalışma zamanında çağrılır. HTTP request pipeline'ını burada yapılandırın.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Money Transfer API V1");
                });
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}