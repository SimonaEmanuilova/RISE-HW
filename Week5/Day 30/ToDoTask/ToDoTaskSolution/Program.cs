using Microsoft.EntityFrameworkCore;
using Prometheus;
using ToDoTaskSolution.Entities;
using ToDoTaskSolution.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TODOTASKSContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
builder.Services.AddScoped<IToDoListService, ToDoListService>();

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

//prometheus
app.UseMetricServer();



app.Run();
