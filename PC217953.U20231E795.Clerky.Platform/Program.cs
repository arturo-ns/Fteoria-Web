using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using MySql.EntityFrameworkCore.Extensions;
using PC217953.U20231E795.Clerky.Platform.Incorporation.application;
using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.repositories;
using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.services;
using PC217953.U20231E795.Clerky.Platform.Incorporation.infrastructure.persistence.EFC.context;
using PC217953.U20231E795.Clerky.Platform.Incorporation.infrastructure.persistence.EFC.repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Stripe Atlas API",
        Version = "v1",
        Description = "RESTful API for Stripe Atlas Startup Incorporation management",
        Contact = new OpenApiContact
        {
            Name = "PC217953 U20231E795",
            Email = "student@example.com"
        }
    });

    c.EnableAnnotations();

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

builder.Services.AddDbContext<StartupIncorporationContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!));

builder.Services.AddScoped<IStartupIncorporationCommandService, StartupIncorporationCommandService>();
builder.Services.AddScoped<IStartupIncorporationRepository, StartupIncorporationRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stripe Atlas API v1");
    });
}

var supportedCultures = new[] { "en", "en-US", "es", "es-PE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<StartupIncorporationContext>();
    context.Database.EnsureCreated();
}

app.Run();
