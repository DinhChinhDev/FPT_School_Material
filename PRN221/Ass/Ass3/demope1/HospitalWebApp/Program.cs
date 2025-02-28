using HospitalBusiness;
using HospitalRepositories;
using HospitalRepositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IGenericRepository<Doctor>, GenericRepository<Doctor>>();
builder.Services.AddScoped<IGenericRepository<Patient>, GenericRepository<Patient>>();
builder.Services.AddScoped<IGenericRepository<Appointment>, GenericRepository<Appointment>>();


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

//dua duong dan

app.MapGet("/", (context) =>
{
    context.Response.Redirect("/Appointments/index"); // Adjust the path to your actual login page
    return Task.CompletedTask;
});

app.Run();
