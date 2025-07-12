namespace PrintJsBlazor.Wrappers.LogWrapper;

public class ConsoleWrapper:ILogWrapper
{
    public Task Log(string message)
    {
        Console.WriteLine(message);
        return Task.CompletedTask;
    }
}