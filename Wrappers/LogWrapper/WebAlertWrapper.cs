using CurrieTechnologies.Razor.SweetAlert2;

namespace PrintJsBlazor.Wrappers.LogWrapper;

public class WebAlertWrapper(SweetAlertService swal) : ILogWrapper
{
    public async Task Log(string message)
    {
        await swal.FireAsync("Oops...", message, "error");
    }
}