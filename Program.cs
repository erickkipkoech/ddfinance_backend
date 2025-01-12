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

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddScoped<IInsurancePolicies, InsurancePoliciesRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddScoped<IValidator<AddEditInsurancePoliciesRequest>, AddEditInsurancePoliciesRequestValidation>();
builder.Services.AddScoped<IValidator<GetInsurancePoliciesByIdRequest>, GetInsurancePoliciesByIdRequestValidation>();
builder.Services.AddScoped<IValidator<DeleteInsurancePoliciesRequest>, DeleteInsurancePoliciesRequestValidation>();

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

app.Run();

