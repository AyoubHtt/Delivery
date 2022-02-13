using API.Infrastructure.AutofacModules;
using API.Infrastructure.DbContextConfiguration;
using API.Infrastructure.Filter;
using API.Infrastructure.Swagger;
using Autofac;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => { options.Filters.Add(typeof(HttpGlobalExceptionFilter)); })
                .AddJsonOptions(options => { options.JsonSerializerOptions.WriteIndented = true; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddCustomDbContext(builder.Configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new ApplicationModule());
    builder.RegisterModule(new MediatorModule());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => { c.AllowAnyHeader(); c.AllowAnyMethod(); });

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseSwaggerSetup();

app.Run();
