using PRN221_DinhChinh_Ass3.DataAccess.Repository;
using PRN221_DinhChinh_Ass3.DataAccess.Repository.IRepositories;
using PRN221_DinhChinh_Ass3.Model;
using PRN221_DinhChinh_Ass3.DataAccess;
using PRN221_DinhChinh_Ass3.WebApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddSession();
builder.Services.AddScoped<AppDbContext, AppDbContext>(); // Add Scopre
builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<IGenericRepository<AppUser>, GenericRepository<AppUser>>();
builder.Services.AddScoped<IGenericRepository<Book>, GenericRepository<Book>>();
builder.Services.AddScoped<IGenericRepository<Ship>, GenericRepository<Ship>>();

var app = builder.Build();//
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseSession();
app.MapGet("/", (context) =>
{
    context.Response.Redirect("/Login/Login"); // Adjust the path to your actual login page
    return Task.CompletedTask;
});
app.MapHub<BookHub>("/bookHub");
app.Run();
