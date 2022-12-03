<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using Webapi.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
    builder.Services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString"]));
    builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = "http://localhost:7229",
            ValidAudience = "http://localhost:7229",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"])),
        };
    });
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

=======
﻿using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Webapi.Contexts;
using Webapi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
//builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

>>>>>>> 885ce6c3f4ead2c34edf8f810e97aaa8db77b916
app.Run();