using API.Infrastructure.Filter;
using API.Infrastructure.Swagger;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace API;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        // WebAPI Configuration
        services.AddControllers(options => { options.Filters.Add(typeof(HttpGlobalExceptionFilter)); })
                .AddJsonOptions(options => { options.JsonSerializerOptions.WriteIndented = true; });

        services.AddMvcCore().AddApiExplorer();

        // Swagger Configuration
        services.AddSwaggerConfiguration();

        services.AddRazorPages();

        var container = new ContainerBuilder();
        container.Populate(services);

        //container.RegisterModule(new ApplicationModule());

        return new AutofacServiceProvider(container.Build());
    }

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

        app.UseCors(c => { c.AllowAnyHeader(); c.AllowAnyMethod(); });

        app.UseRouting();

        app.UseAuthorization();
        
        app.UseEndpoints(endpoints => endpoints.MapControllers());

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseAuthentication();

        app.UseSwaggerSetup();
    }
}

