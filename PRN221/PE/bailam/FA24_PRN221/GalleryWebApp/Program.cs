using GalleryBusiness;
using GalleryRepositories.IRepositories;
using GalleryRepositories;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IGenericRepository<Artist>, GenericRepository<Artist>>();
builder.Services.AddScoped<IGenericRepository<Artwork>, GenericRepository<Artwork>>();
builder.Services.AddScoped<IGenericRepository<Exhibition>, GenericRepository<Exhibition>>();
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

app.Run();
