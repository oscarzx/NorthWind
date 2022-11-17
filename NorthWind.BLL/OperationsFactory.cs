using NorthWind.Services;

namespace NorthWind.BLL;

public static class OperationsFactory
{
    public static ICategoryOperations GetCategoryOperations()
    {
        return new CategoryOperations();
    }

    public static ILogOperations GetLogOperations()
    {
        return new LogOperations();
    }
}
