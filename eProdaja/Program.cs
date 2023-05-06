using eProdaja.DataBase;
using eProdaja.Model.ProductStateMachine;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using eProdaja.Services.ProductStateMachine;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddSingleton<IProizvodiService, ProizvodiService>();

builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<IJediniceMjereService, JediniceMjereService>();
builder.Services.AddTransient<IProizvodiService,ProizvodiService>();
builder.Services.AddTransient<IVrsteProizvodumService, VrsteProizvodumService>();

builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<InitialProductState>();
builder.Services.AddTransient<DraftProductState>();
builder.Services.AddTransient<ActiveProductState>();

builder.Services.AddDbContext<EProdajaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(IKorisniciService));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
