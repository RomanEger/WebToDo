using WebToDo.Services;

var builder = WebApplication.CreateBuilder(args);

var conStr = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IUserData, SqlUsersData>();
builder.Services.AddScoped<ITaskData, SqlTasksData>();

builder.Services.AddAuthentication();

builder.Services.AddMvc();

var app = builder.Build();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseStaticFiles();

app.Run();
