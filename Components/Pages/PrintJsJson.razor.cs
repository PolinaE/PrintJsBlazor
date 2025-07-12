using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PrintJsBlazor.Wrappers.LogWrapper;

namespace PrintJsBlazor.Components.Pages;

public partial class PrintJsJson(WebConsoleWrapper webConsoleWrapper, IConfiguration configuration, ConsoleWrapper consoleWrapper, WebAlertWrapper webAlertWrapper)
{
    [Inject] 
    private IJSRuntime Js { get; set; }
    [Inject] 
    private SweetAlertService Swal { get; set; }

    private string InputJson { get; set; } = configuration.GetValue<string>("Examples:TextJson") ?? string.Empty;

     private Lazy<IJSObjectReference> _printJsModule = new();
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        _printJsModule = new Lazy<IJSObjectReference>(await Js.InvokeAsync<IJSObjectReference>("import", "../Components/Pages/PrintJsJson.razor.js"));
    }
    
    private async Task<bool> CheckJson() => await _printJsModule.Value.InvokeAsync<bool>("checkTextByPrintEditor");
    private async Task<bool> JsonIsArray() => await _printJsModule.Value.InvokeAsync<bool>("jsonIsArray");
    
    
    private async Task TransmitCode()
    {
        await consoleWrapper.Log("interestiung expierence");
        await webAlertWrapper.Log("very interestiung expierence");
        await webConsoleWrapper.Log("very very interestiung expierence");
        if (!await CheckJson())
            await Swal.FireAsync("Oops...","JSON is not valid, please fix it", "error");
        else await _printJsModule.Value.InvokeVoidAsync("doBeauty", InputJson);
        await webConsoleWrapper.Log("Yyyyee");
    }
    
    private async Task PrintJson()
    {
        if (!(await CheckJson()))
        {
            await Swal.FireAsync("Oops...","JSON is not valid, please fix it", "error");
            return;
        }
        if (!(await JsonIsArray()))
        {
            await Swal.FireAsync("Oops...","It works only with arrays", "error");
            return;
        }

        object distinctJsonKeys = await Js.InvokeAsync<dynamic>("getArrayKeys");
        await Js.InvokeVoidAsync("printJson", distinctJsonKeys);
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or
    /// resetting unmanaged resources asynchronously.</summary>
    /// <returns>A task that represents the asynchronous dispose operation.</returns>
    public async ValueTask DisposeAsync()
    {
        if(_printJsModule.IsValueCreated)
        {
            await _printJsModule.Value.DisposeAsync();
            // GC.SuppressFinalize(this);
        }
    }
}