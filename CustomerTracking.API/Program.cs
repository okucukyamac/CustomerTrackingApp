using CustomerTracking.API.Filters;
using CustomerTracking.API.Middlewares;
using CustomerTracking.Core.Repositories;
using CustomerTracking.Core.Services;
using CustomerTracking.Core.UnitOfWorks;
using CustomerTracking.Repository;
using CustomerTracking.Repository.Repositories;
using CustomerTracking.Repository.UnitOfWorks;
using CustomerTracking.Service.Mapping;
using CustomerTracking.Service.Services;
using CustomerTracking.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(a=>a.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IProductReporsitory, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService,CategoryService>();


builder.Services.AddDbContext<AppDbContext>(a =>
{
    a.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
