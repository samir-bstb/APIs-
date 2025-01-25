using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios para controladores y Swagger
builder.Services.AddControllers(); // Registra los controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MathOp API", Version = "v1" });
});

var app = builder.Build();

// Usar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MathOp API v1");
    });
}

//app.UseHttpsRedirection();

app.MapControllers(); // Mapear los controladores

app.Run();
