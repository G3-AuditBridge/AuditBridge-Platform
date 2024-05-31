using AuditBridgePlatform.Profiles.Application.Internal.CommandServices;
using AuditBridgePlatform.Profiles.Application.Internal.QueryServices;
using AuditBridgePlatform.Profiles.Domain.Repositories;
using AuditBridgePlatform.Profiles.Domain.Services;
using AuditBridgePlatform.Profiles.Infrastructure.Persistence.EFC.Repositories;
using AuditBridgePlatform.Profiles.Interfaces.ACL;
using AuditBridgePlatform.Profiles.Interfaces.ACL.Services;
using AuditBridgePlatform.Shared.Domain.Repositories;
using AuditBridgePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using AuditBridgePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using AuditBridgePlatform.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

//Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "AuditBridgePlatform.API",
                Version = "v1",
                Description = "Audit Bridge Platform API",
                TermsOfService = new Uri("https://auditbridge.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "Circle Up Studios",
                    Email = "contact@circleup.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    }
    );

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Profiles Bounded Context Injection Configuration
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
builder.Services.AddScoped<IProfilesContextFacade, ProfilesContextFacade>();

var app = builder.Build();


// Verify Database Objects area Created

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();