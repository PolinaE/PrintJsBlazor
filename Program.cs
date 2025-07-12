using CurrieTechnologies.Razor.SweetAlert2;
using PrintJsBlazor.Components;
using PrintJsBlazor.Wrappers.LogWrapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSweetAlert2();
builder.Services.AddSingleton<ConsoleWrapper>();
builder.Services.AddScoped<WebConsoleWrapper>();
builder.Services.AddScoped<WebAlertWrapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
