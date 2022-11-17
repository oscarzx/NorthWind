using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NorthWind.DAL;
using NorthWind.Entities;
using NorthWind.Services;

namespace NorthWind.BLL;

public class CategoryOperations : ICategoryOperations
{
    public Category Create(Category category)
    {
        if (!string.IsNullOrWhiteSpace(category.CategoryName))
        {
            using(var repository = NorthWindRepositoryFactory.GetNorthWindRepository())
            {
                category = repository.CreateCategory(category);
            }
        }
        else
        {
            category = null;
        }
        return category;
    }

    public bool Delete(int categoryID)
    {
        bool result = false;
        using (var repository = NorthWindRepositoryFactory.GetNorthWindRepository())
        {
            result = repository.DeleteCategory(categoryID);
        }
        return result;
    }

    public bool DeleteWithLog(int categoryID)
    {
        bool result = false;
        using(var repository = NorthWindRepositoryFactory.GetNorthWindRepository(true))
        {
            repository.DeleteCategory(categoryID);
            Log log = new Log
            {
                Type = LogType.DeleteCategory,
                Message = $"ID: {categoryID}"
            };
            repository.CreateLog(log);
            result = repository.SaveChanges() == 2;
        }
        return result;
    }

    public List<Category> GetAll()
    {
        return NorthWindRepositoryFactory.GetNorthWindRepository().GetCategories();
    }

    public Category RetrieveByID(int categoryID)
    {
        Category result = null;
        if(categoryID > 0)
        {
            using(var repository = NorthWindRepositoryFactory.GetNorthWindRepository())
            {
                result = repository.RetrieveCategoryByID(categoryID);
            }
        }
        return result;
    }

    public bool Update(Category category)
    {
        bool result = false;
        using(var repository = NorthWindRepositoryFactory.GetNorthWindRepository())
        {
            result = repository.UpdateCategory(category);
        }
        return result;
    }
}
