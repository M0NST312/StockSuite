using Microsoft.EntityFrameworkCore;
using StockSuite.SSContext;
using Microsoft.AspNetCore.Identity;
using StockSuite.Data;


var builder = WebApplication.CreateBuilder(args);
var ssContextConnection = builder.Configuration.GetConnectionString("SSContext");
var identityContext = builder.Configuration.GetConnectionString("StockSuiteContextConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SSDBContext>(options => options.UseSqlServer(ssContextConnection));
builder.Services.AddDbContext<StockSuiteContext>(options => options.UseSqlServer(identityContext));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<StockSuiteContext>();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
