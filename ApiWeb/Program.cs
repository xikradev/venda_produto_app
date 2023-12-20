using Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

string server = "MICRO-12\\SQLEXPRESS";
string database = "prodVendaDb";
string username = "sa";
string password = "abcde.123";

//var connectionString = $"Data Source={server};Initial Catalog={database};Integrated Security=False;User Id={username};Password={password};Connection Timeout=10;TrustServerCertificate=True;MultipleActiveResultSets=True";

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DBContext>(options =>
              options.UseSqlServer(connectionString));

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
