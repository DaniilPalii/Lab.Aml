using Microsoft.AspNetCore.Mvc;

namespace Lab.Aml.WebApi.Controllers;

[ApiController]
public sealed class ErrorController : ControllerBase
{
	[Route("/error"), ApiExplorerSettings(IgnoreApi = true)]
	public IActionResult HandleError()
	{
		return Problem();
	}
}
