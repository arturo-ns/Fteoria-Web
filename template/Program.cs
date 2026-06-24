using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using MySql.EntityFrameworkCore.Extensions;
using pc217953u20231e795.API.{BoundedContext}.application;
using pc217953u20231e795.API.{BoundedContext}.domain.repositories;
using pc217953u20231e795.API.{BoundedContext}.domain.services;
using pc217953u20231e795.API.{BoundedContext}.infrastructure.persistence.EFC.context;
using pc217953u20231e795.API.{BoundedContext}.infrastructure.persistence.EFC.repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "{DatabaseSchema} API",
        Version = "v1",
        Description = "RESTful API for {DatabaseSchema} management",
        Contact = new OpenApiContact
        {
            Name = "{AuthorName}",
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

builder.Services.AddDbContext<{Entity}Context>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!));

builder.Services.AddScoped<I{Entity}CommandService, {Entity}CommandService>();
builder.Services.AddScoped<I{Entity}Repository, {Entity}Repository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "{DatabaseSchema} API v1");
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
    var context = scope.ServiceProvider.GetRequiredService<{Entity}Context>();
    context.Database.EnsureCreated();
}

app.Run();
