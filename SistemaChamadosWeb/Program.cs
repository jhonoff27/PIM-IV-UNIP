using SistemaChamadosWeb;
using SistemaChamadosWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Razor Components (.NET 8)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Serviços
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<AppState>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// 👉 ADICIONE AQUI
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
