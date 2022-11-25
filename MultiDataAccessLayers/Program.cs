using AutoMapper;
using DataAccessLayerEntityFrameWork.ContextDbs;
using DataAccessLayerEntityFrameWork.Repository;
using DataAccessLayerMongoDB.IServices;
using DataAccessLayerMongoDB.Services;
using DataAccessLayerMongoDB.Setting;
using DomainLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ServicesLayer.HrServices;
using ServicesLayer.IServices.HrServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.Configure<EmployeeDatabaseSettings>(config.GetSection(nameof(EmployeeDatabaseSettings)));

builder.Services.AddSingleton<IEmployeeDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<EmployeeDatabaseSettings>>().Value);
builder.Services.AddScoped<IOrderingServices, OrderingServices>();

builder.Services.AddDbContext<DbContextSystem>(options =>
            options.UseSqlServer(config.GetConnectionString("MvcCoreMovieContext")));

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IEmployeeDepartmentService, EmployeeDepartmentService>();

builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("HR", new OpenApiInfo
    {
        Title = "HRManagement",
        Version = "v1"
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/HR/swagger.json", "HRManagement v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
