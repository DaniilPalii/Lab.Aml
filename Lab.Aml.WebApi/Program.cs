using Lab.Aml.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
Database.AddTo(builder);
Services.AddTo(builder);
Swagger.AddTo(builder);

var app = builder.Build();

Swagger.UseIn(app);
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
