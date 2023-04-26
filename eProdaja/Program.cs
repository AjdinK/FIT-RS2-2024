using eProdaja.DataBase;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<IService<eProdaja.Model.JediniceMjere , object>, BaseService<eProdaja.Model.JediniceMjere,JediniceMjere , object>>();
builder.Services.AddTransient<IService<eProdaja.Model.Proizvodi , ProizvodiSearchObject>, BaseService<eProdaja.Model.Proizvodi, Proizvodi , ProizvodiSearchObject>>();


//builder.Services.AddSingleton<IProizvodiService, ProizvodiService>();

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
