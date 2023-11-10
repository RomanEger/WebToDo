var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();

builder.Services.AddMvc();

var app = builder.Build();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseStaticFiles();

app.Run();
