using System.Text;
using api.Context;
using api.Models.AppTables;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connStr = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDbContext>(options=>{
    options.UseMySql(connStr, ServerVersion.AutoDetect(connStr)); 
});

//identity core service
builder.Services.AddIdentity<User, IdentityRole>(option =>
{
    option.Password.RequiredLength = 6;
    option.Password.RequireDigit = true;
    option.Password.RequireUppercase = true;
    option.Password.RequireNonAlphanumeric = false;
    option.Lockout.AllowedForNewUsers = false;
})
.AddRoles<IdentityRole>() //be able to add role
.AddRoleManager<RoleManager<IdentityRole>>() //able to make use of roleManager
.AddEntityFrameworkStores<AppDbContext>() //providing our context
.AddSignInManager<SignInManager<User>>() //make use of sign in manager
.AddUserManager<UserManager<User>>() //make use of usermanager to create user
.AddDefaultTokenProviders() //able to create tokens)
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();



//able to authenticate user using JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateIssuer = true,
            ValidateAudience = false
        };
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
