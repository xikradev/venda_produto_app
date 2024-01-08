using AppWebApi.Profiles;
using AppWebApi.ServicesCollection;
using Data.Context;
using Domain.Models.Identity_Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var noteconnectionString = builder.Configuration.GetConnectionString("NotebookConnection");

//builder.Services.AddDbContext<DBContext>(options =>
//    options.UseLazyLoadingProxies().UseSqlServer(connectionString));

//builder.Services.AddDbContext<UserDbContext>(options =>
//    options.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddDbContext<DBContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(noteconnectionString));

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(noteconnectionString));

builder.Services.AddIdentity<User, Roles>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders()
    .AddSignInManager();

builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddVendaProdutoContext();
builder.Services.AddVendaProdutoServices();

var devClient = "http://localhost:4200";
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(devClient)
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<ProductProfile>();
    config.AddProfile<AddressProfile>();
    config.AddProfile<ClientProfile>();
}, typeof(Program));



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Venda_Produto", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authentication header using the Bearer scheme.
                        Enter 'Bearer' [space] and then your token in the text input below.
                        Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Venda_Produto v1"));

app.Run();