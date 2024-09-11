using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;
using GameStore.Frontend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var gameStoreAPIURL = builder.Configuration["GameStoreAPIURL"] ?? throw new Exception("GameStore API URL is Not Set!");

//Registering Both Clients and their respective HTTP Clients 
builder.Services.AddHttpClient<GamesClient>(client => client.BaseAddress = new Uri(gameStoreAPIURL));
builder.Services.AddHttpClient<GenresClient>(client => client.BaseAddress = new Uri(gameStoreAPIURL));


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// todo Uncomment on Production
//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
