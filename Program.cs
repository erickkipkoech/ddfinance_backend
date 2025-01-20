using DDFinanceBackend.Data;
using DDFinanceBackend.Models.Requests;
using DDFinanceBackend.Repository;
using DDFinanceBackend.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assemblyName = typeof(Program).Assembly.GetName().Name;


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"), m => m.MigrationsAssembly(assemblyName)
    ));

builder.Services.AddScoped<IInsurancePolicies, InsurancePoliciesRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddScoped<IValidator<AddEditInsurancePoliciesRequest>, AddEditInsurancePoliciesRequestValidation>();
builder.Services.AddScoped<IValidator<GetInsurancePoliciesByIdRequest>, GetInsurancePoliciesByIdRequestValidation>();
builder.Services.AddScoped<IValidator<DeleteInsurancePoliciesRequest>, DeleteInsurancePoliciesRequestValidation>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
if (context.Database.GetPendingMigrations().Any())
{
    await context.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
  policy.WithOrigins("http://localhost:4200",
                    "http://3.90.29.28",
                    "http://ec2-3.90.29.28.compute-1.amazonaws.com")
        .AllowAnyHeader()
        .AllowAnyMethod());


//app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

