using Microsoft.EntityFrameworkCore;
using Zahradnictvi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();  // <-- pøidá MVC podporu



builder.Services.AddDbContext<ContactFormContext>(options =>
    options.UseSqlite("Data Source=contactforms.db"));
builder.Services.AddDbContext<ContactFormContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();              // <-- pro MVC controllery
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
