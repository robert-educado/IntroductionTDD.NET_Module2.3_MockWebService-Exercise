using BancoLibre.Application.Interfaces;
using BancoLibre.Application.Services;
using BancoLibre.Domain.Interfaces;
using BancoLibre.Infrastructure.Providers;
using BancoLibre.UnitTests.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICreditScoreProvider, CreditScoreProvider>();
builder.Services.AddScoped<ILoanApplicationEvaluator, LoanApplicationEvaluator>();
builder.Services.AddScoped<ILoanApplicationProcessor, LoanApplicationProcessor>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
