using DucatiWebApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);
var AllowMySpecificOrigins = "_allowMySpecificOrigins";


builder.Services.AddDbContext<DucatiWebApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DucatiWebApiContext")));

builder.Services.AddScoped(p =>
{
    var context = p.GetRequiredService<IDbContextFactory<DucatiWebApiContext>>().CreateDbContext();
    context.Database.EnsureCreated();

    return context;
});

builder.Services
.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidAudience = builder.Configuration.GetConnectionString("DucatiWebApiContext"),
        ValidateIssuer = false,
        ValidIssuer = builder.Configuration.GetConnectionString("DucatiWebApiContext"),
        ValidateLifetime = false,
        ValidateIssuerSigningKey = false,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Constants.JwtKey)),
    };
});
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowMySpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500").AllowAnyMethod().AllowAnyHeader();

                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowMySpecificOrigins);

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
