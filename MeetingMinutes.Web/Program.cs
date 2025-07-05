using MeetingMinutes.Application.ServiceInterface;
using MeetingMinutes.Application.Services;
using MeetingMinutes.Infrastructure.DBContext;
using MeetingMinutes.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Database
var config = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IDbContext>(sp =>
    new DapperDbContext(config));

//Repository
builder.Services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
builder.Services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
//Services
builder.Services.AddScoped<ICustomerService, CustomerService>();


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
