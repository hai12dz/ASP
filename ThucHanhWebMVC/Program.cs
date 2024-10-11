using Microsoft.EntityFrameworkCore;
using ThucHanhWebMVC.Models;
using ThucHanhWebMVC.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//cau hinh de su dung viewcomponent va interface cho lop LoaiRepository no dung theo DI
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("MasterContext");
builder.Services.AddDbContext<MasterContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<ILoaiSpRepository, LoaiSpRepository>();
//toan bo 4 cau tren

//add session video 13
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

app.UseRouting();

app.UseAuthorization();

//session cho video 13
app.UseSession();


app.MapControllerRoute(
    name: "default",
    //dang nhap truoc
  //  pattern: "{controller=Access}/{action=Login}/{id?}");


pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
