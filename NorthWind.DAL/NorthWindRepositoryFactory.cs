using NorthWind.Services;

namespace NorthWind.DAL;

public static class NorthWindRepositoryFactory
{
    public static INorthWindRepository GetNorthWindRepository(bool isUnitOfWork = false)
    {
        return new NorthWindRepository(isUnitOfWork);
    }
}
