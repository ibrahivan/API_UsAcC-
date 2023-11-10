using API_UsAcC_;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Se define un nuevo servicio en el contenedor de servicios
// que generará el contexto de conexión a base de datos
// para la sesión https de usuario.

builder.Services.AddDbContext<Contexto>(
     o => o.UseNpgsql(builder.Configuration.GetConnectionString("CadenaConexionPostgreSQL")));

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

app.Run();
