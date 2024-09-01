using Microsoft.OpenApi.Models;

namespace Lab.Aml.WebApi;

internal static class Swagger
{
	public static void AddTo(WebApplicationBuilder builder)
	{
		builder.Services.AddEndpointsApiExplorer();

		builder.Services.AddSwaggerGen(options =>
		{
			options.MapType<DateOnly>(() => new OpenApiSchema
			{
				Type = "string",
				Format = "date"
			});
		});
	}

	public static void UseIn(WebApplication application)
	{
		application.UseSwagger();
		application.UseSwaggerUI(config =>
		{
			// Disabling syntax highlighting to improve render speed for large reponses
			config.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
			{
				["activated"] = false,
			};
		});
	}
}
