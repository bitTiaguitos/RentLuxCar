using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Website_TI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Website_TIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Website_TIContext") ?? throw new InvalidOperationException("Connection string 'Website_TIContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
