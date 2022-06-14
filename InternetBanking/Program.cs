using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using InternetBanking.Models;
using InternetBanking.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InternetBankingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InternetBankingContext") ?? throw new InvalidOperationException("Connection string 'InternetBankingContext' not found.")));

builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer("Data Source = PARULSEHOTRA\\SQLEXPRESS; Initial Catalog = Register; Integrated Security = True"));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();

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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
