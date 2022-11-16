
using NorthWind.Entities;

namespace NorthWind.Services;

public interface ICategoryOperations
{
    Category Create(Category category);
    Category RetrieveByID(int categoryID);
    bool Update(Category category);
    bool Delete(int categoryID);
    List<Category> GetAll();
    bool DeleteWithLog(int categoryID);
}
