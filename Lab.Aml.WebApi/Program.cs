using Lab.Aml.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
	options.Filters.Add<HttpResponseExceptionFilter>());

builder.Services.AddEndpointsApiExplorer();
Database.AddTo(builder);
Services.AddTo(builder);
Swagger.AddTo(builder);
BackgroundJobs.Configure(builder);

var app = builder.Build();

Swagger.UseIn(app);
BackgroundJobs.UseIn(app);
app.UseHttpsRedirection();
app.MapControllers();

#if RELEASE
app.UseExceptionHandler("/error");
#endif

app.Run();
