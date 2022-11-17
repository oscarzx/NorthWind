using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities;
using NorthWind.Services;

namespace NorthWind.Web.Controllers;

public class CategoriesController : Controller
{
    ICategoryOperations Helper;
	public CategoriesController(ICategoryOperations categoryOperations)
	{
		this.Helper = categoryOperations;
	}

	public IActionResult Create(string name, string description)
	{
		IActionResult result;
		Category category = new Category
		{
			CategoryName = name,
			Description = description
		};

		category = Helper.Create(category);
		if(category != null)
		{
			//Content se utiliza para devolver código html
			result = Content($"Entidad insertada {category.CategoryID}");
		}
		else
		{
			result = Content("No se pudo insertar la categoría");
		}
		return result;
	}

	public IActionResult Retrieve(int id)
	{
		IActionResult result;
		var category = Helper.RetrieveByID(id);
		if(category != null)
		{
			result = Content($"Entidad encontrada {category.CategoryID}, {category.CategoryName}");
		}
		else
		{
			result = Content("No se pudo encontrar la categoría");
		}
		return result;
	}

	public IActionResult Update(int id, string name, string description)
	{
		IActionResult result;
		Category category = new()
		{
			CategoryID = id,
			CategoryName = name,
			Description = description
		};

		var updateResult = Helper.Update(category);
		if (updateResult)
		{
			result = Content("Categoría modificada");
		}
		else
		{
			result = Content("No se pudo actualizar la categoría");
		}
		return result;
	}

	public IActionResult Delete(int id, bool withLog = false)
	{
		IActionResult result;

		var deleteResult = withLog ? Helper.DeleteWithLog(id)
			: Helper.Delete(id);

		if (deleteResult)
		{
			result = Content("Categoría eliminada");
		}
		else
		{
			result = Content("No se pudo eliminar la categoría");
		}
		return result;
	}

	public IActionResult All()
	{
		var model = Helper.GetAll();
		return View(model);
	}
}
