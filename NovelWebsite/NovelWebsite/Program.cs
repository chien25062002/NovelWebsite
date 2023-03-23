using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NovelWebsite.Entities;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NovelWebsite")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = "/Admin/Account/Login";
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();           
builder.Services.AddSession(cfg => {                   
    cfg.Cookie.Name = "novelwebsite";             
    cfg.IdleTimeout = new TimeSpan(0, 30, 0);    
});

builder.Services.AddSingleton<IHostedService, CacheUpdateService>();
builder.Services.AddMemoryCache();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "reviews",
      pattern: "review/{categoryId?}",
      defaults: new { controller = "Review", action = "Index"});

    endpoints.MapControllerRoute(
     name: "filter",
     pattern: "bo-loc/",
     defaults: new { controller = "Filter", action = "Index" });

    /*    endpoints.MapControllerRoute(
          name: "truyen",
          pattern: "truyen/{slug}-{createddate}{id}",
          defaults: new {controller = "Book", action = "Index"});*/

    /*    endpoints.MapControllerRoute(
          name: "tintuc",
          pattern: "tin-tuc/{slug}-{createddate}{id}",
          defaults: new { controller = "Post", action = "Index" });

        endpoints.MapControllerRoute(
          name: "chuong",
          pattern: "truyen/{slug}-{createddate}{id}-chuong-{chapternumber?}-{chapterslug?}",
          defaults: new { controller = "Chapter", action = "Index" });*/
});

// Create Database If Not Exists
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();
    } catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}
app.Run();
