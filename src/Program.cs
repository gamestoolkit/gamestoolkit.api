using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using gamestoolkit.api.Repositories;
using DapperRepos = gamestoolkit.api.Repositories.Dapper;
using EFRepos = gamestoolkit.api.Repositories.EF;
using DapperQueries = gamestoolkit.api.Queries.Dapper;
using EFQueries = gamestoolkit.api.Queries.EF;
using gamestoolkit.api.Queries;
using gamestoolkit.api.Services;
using gamestoolkit.api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var useDapper = true;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PostServices>();

if (useDapper)
{
    builder.Services.AddSingleton<GTKDapperContext>();

    builder.Services.AddScoped<IPostRepository, DapperRepos.PostRepository>();

    builder.Services.AddScoped<IPostQueries, DapperQueries.PostQueries>();
    
}
else
{
    builder.Services.AddDbContext<GTKContext>(options =>
        options.UseLazyLoadingProxies()
               .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<IPostRepository, EFRepos.PostRepository>();

    builder.Services.AddScoped<IPostQueries, EFQueries.PostQueries>();
}

builder.Services.AddAutoMapper(typeof(Program));


// Errors
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
