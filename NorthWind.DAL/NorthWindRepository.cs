using NorthWind.Entities;
using NorthWind.Services;
using System.Linq;

namespace NorthWind.DAL;

public class NorthWindRepository : INorthWindRepository, IDisposable
{
    NorthWindContext context;
    bool IsUnitOfWork;

    public NorthWindRepository(bool isUnitOfWork = false)
    {
        this.context = new NorthWindContext();
        this.IsUnitOfWork= isUnitOfWork;
    }

    public int SaveChanges()
    {
        var result = 0;
        if (context != null)
        {
            try
            {
                result = context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        return result;
    }

    private bool Save()
    {
        int changes = 0;
        if (!IsUnitOfWork)
        {
            changes = SaveChanges();
        }
        return changes == 1;
    }

    public Category CreateCategory(Category category)
    {
        category = context.Add(category).Entity;
        Save();
        return category;
    }

    public Category RetrieveCategoryByID(int categoryID)
    {
        return context.Find<Category>(categoryID);
    }

    public bool UpdateCategory(Category category)
    {
        context.Update(category);
        return Save();
    }

    public bool DeleteCategory(int categoryID)
    {
        context.Remove(new Category { CategoryID = categoryID });
        return Save();
    }

    public List<Category> GetCategories()
    {
        return context.Categories.ToList();
    }

    public Log CreateLog(Log log)
    {
        log = context.Add(log).Entity;
        Save();
        return log;
    }

    public List<Log> GetLogs()
    {
        return context.Logs.ToList();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
