using Microsoft.EntityFrameworkCore;
using ResumeSample.Core.Services.Implementetions;
using ResumeSample.Core.Services.Interfaces;
using ResumeSample.Data.Context;
using ResumeSample.IOC;
using ResumeSample.Data.Repositories;
using ResumeSample.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Add Db Context
builder.Services.AddDbContext<ResumSampleContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ResumeConnectionString"));
});
#endregion



builder.Services.RegisterServices();
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
