using Microsoft.JSInterop;

namespace PrintJsBlazor.Wrappers.LogWrapper;

public class WebConsoleWrapper(IJSRuntime js) : ILogWrapper
{
    public async Task Log(string message)
    {
        await js.InvokeVoidAsync("console.log", message);
    }
}
