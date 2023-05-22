using eProdaja.DataBase;
using eProdaja.Filters;
using eProdaja.Model.ProductStateMachine;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using eProdaja.Services.ProductStateMachine;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(x => x.Filters.Add<ErrorFilter>()).AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {

    c.AddSecurityDefinition("BasicAuthentication", new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic" });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {{
            new OpenApiSecurityScheme{ Reference = new OpenApiReference
            {Type = ReferenceType.SecurityScheme , Id = "BasicAuthentication"}},
            new string []{ }}
    });});

//builder.Services.AddSingleton<IProizvodiService, ProizvodiService>();

builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<IJediniceMjereService, JediniceMjereService>();
builder.Services.AddTransient<IProizvodiService,ProizvodiService>();
builder.Services.AddTransient<IVrsteProizvodumService, VrsteProizvodumService>();
builder.Services.AddTransient<IService<eProdaja.Model.Uloge, BaseSearchObject>,
BaseService<eProdaja.Model.Uloge, Uloge, BaseSearchObject>>();
builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<InitialProductState>();
builder.Services.AddTransient<DraftProductState>();
builder.Services.AddTransient<ActiveProductState>();

builder.Services.AddDbContext<EProdajaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(IKorisniciService));

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
    ("BasicAuthentication", null);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
using (var scope = app.Services.CreateScope()) {
    var dataContext = scope.ServiceProvider.GetRequiredService<EProdajaContext>();
    dataContext.Database.Migrate();
}
app.Run();
