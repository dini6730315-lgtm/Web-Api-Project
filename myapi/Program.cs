using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Models;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddDbContext<MyDataBaseContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString())
builder.Services.AddDbContext<MyDataBaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString
("Data Source=srv2\\pupils;Initial Catalog=MyDataBase;Integrated Security=True;" +
"Trust Server Certificate=True")), ServiceLifetime.Transient);
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
