using HR_Management.MVC.Services.Base;
using HR_Managment.MVC.Contracts;
using HR_Managment.MVC.Services;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);
var apiAddr = builder.Configuration.GetSection("ApiAddress").Value;
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IClient,Client>(c=>c.BaseAddress=new Uri(apiAddr));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILocalStorageService,LocalStorageService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
