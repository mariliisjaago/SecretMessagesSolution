using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretMessages_Library.Contracts.DataAccess;
using SecretMessages_Library.Contracts.Utilities;
using SecretMessages_Library.DataAccess;
using SecretMessages_Library.Routines;
using SecretMessages_Library.Services;
using SecretMessages_Library.Utilities;

namespace SecretMessagesWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddSession();
            services.AddMemoryCache();

            services.AddScoped<ISqlDbAccess, SqlDbAccess>();
            services.AddScoped<IUserService, SqlUserService>();
            services.AddScoped<IMessageService, SqlMessageService>();

            services.AddScoped<IUserInputValidator, UserInputValidator>();
            services.AddScoped<IPasswordCrypto, PasswordCrypto>();

            services.AddScoped<ILoginRoutine, LoginRoutine>();
            services.AddScoped<IMessageRoutine, MessageRoutine>();
            services.AddScoped<ILookupRoutine, LookupRoutine>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
