using eProdaja.API;
using eProdaja.Services;
using eProdaja.Services.Database;
using eProdaja.Services.ProizvodiStateMachine;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
            },
            new string[] { }
        }
    });
});

var connectionString = builder.Configuration.GetConnectionString("db3");
builder.Services.AddDbContext<EProdajaContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddMapster();

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


builder.Services.AddTransient<IKorisnici, KorisniciService>();
builder.Services.AddTransient<IProizvodi, ProizvodiService>();


builder.Services.AddTransient<BaseProizvodiState>();
builder.Services.AddTransient<InitialProizvodiState>();
builder.Services.AddTransient<DraftProizvodiState>();
builder.Services.AddTransient<ActiveProizvodiState>();
builder.Services.AddTransient<HiddenProizvodiState>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<EProdajaContext>();
    //dataContext.Database.EnsureCreated();
    //dataContext.Database.Migrate();
}

app.Run();