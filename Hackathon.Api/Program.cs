using Hackathon.Api.Profiles;
using Hackathon.Core.Interfaces;
using Hackathon.Core.Services;
using Hackathon.Data;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Metrics;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

builder.Services.AddOpenTelemetry()
    .WithMetrics(builder =>
    {
        builder.AddPrometheusExporter();
        builder.AddMeter("Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Server.Kestrel");
    });

// Add services to the container.

// Configuration de DbContext avec PostgreSQL
builder.Services.AddDbContext<HackathonDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"], x => x.MigrationsAssembly("Hackathon.Api")));

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.HttpOnly = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<Utilisateur>().AddRoles<IdentityRole>().AddEntityFrameworkStores<HackathonDbContext>();

//Ajout de automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Injection de dependance
builder.Services.AddScoped<IAtelierService, AtelierService>();
builder.Services.AddScoped<IVinService, VinService>();
builder.Services.AddScoped<IEcoleService, EcoleService>();
builder.Services.AddScoped<IVisiteurService, VisiteurService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IEvenementService, EvenementService>();
builder.Services.AddScoped<IEvenementVisiteurService, EvenementVisiteurService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IImageEvenementService, ImageEvenementService>();
builder.Services.AddScoped<IHomeDescriptionService, HomeDescriptionService>();

//Repository
builder.Services.AddScoped<IVisiteurRepository, VisiteurRepository>();
builder.Services.AddScoped<IAtelierRepository, AtelierRepository>();
builder.Services.AddScoped<IEvenementRepository, EvenementRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));

var app = builder.Build();

using (var Scope = app.Services.CreateScope())
{
    var context = Scope.ServiceProvider.GetRequiredService<HackathonDbContext>();
    context.Database.Migrate();
}

app.MapPrometheusScrapingEndpoint();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hackathon");
    });
}

app.UseCors("CorsPolicy");

app.MapGroup("api").MapIdentityApi<Utilisateur>().WithTags("identity");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
