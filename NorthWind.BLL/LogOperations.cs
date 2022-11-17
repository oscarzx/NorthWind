using NorthWind.DAL;
using NorthWind.Entities;
using NorthWind.Services;

namespace NorthWind.BLL;

public class LogOperations : ILogOperations
{
    public List<Log> GetLogs()
    {
        return NorthWindRepositoryFactory.GetNorthWindRepository().GetLogs();
    }
}
