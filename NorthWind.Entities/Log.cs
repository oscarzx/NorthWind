
namespace NorthWind.Entities;

public enum LogType
{
    DeleteCategory
}
public class Log
{
    public int LogID { get; set; }
    public DateTime DateTime { get; set; }
    public LogType Type { get; set; }
    public string Message { get; set; }
}
