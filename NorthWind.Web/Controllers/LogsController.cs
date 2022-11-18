using Microsoft.AspNetCore.Mvc;
using NorthWind.Services;

namespace NorthWind.Web.Controllers;

public class LogsController : Controller
{
    private ILogOperations Helper;

	public LogsController(ILogOperations logOperations)
	{
		this.Helper = logOperations;
	}

	public IActionResult All()
	{
		var model = Helper.GetLogs();
		return View(model);
	}
}
