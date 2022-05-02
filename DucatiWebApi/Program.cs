using DucatiWebApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var AllowMySpecificOrigins = "_allowMySpecificOrigins";


builder.Services.AddDbContext<DucatiWebApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DucatiWebApiContext")));


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
