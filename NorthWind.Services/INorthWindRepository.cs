using NorthWind.Entities;

namespace NorthWind.Services;

public interface INorthWindRepository : IDisposable
{
    Category CreateCategory(Category category);
    Category RetrieveCategoryByID(int categoryID);
    bool UpdateCategory(Category category);
    bool DeleteCategory(int categoryID);
    List<Category> GetCategories();
    List<Log> GetLogs();
    Log CreateLog(Log log);
    int SaveChanges();
}   
