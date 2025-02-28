using DemoPE.DataAccess.Data;
using DemoPE.DataAccess.Repositories;
using DemoPE.DataAccess.Repositories.IRepositories;
using DemoPE.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//them builder vo day
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IGenericRepository<Appointment>,GenericRepository<Appointment>>();
builder.Services.AddScoped<IGenericRepository<Doctor>, GenericRepository<Doctor>>();
builder.Services.AddScoped<IGenericRepository<Patient>, GenericRepository<Patient>>();



var app = builder.Build();

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
