using Calculator.Core;

var builder = WebApplication.CreateBuilder(args);

// Register the calculator implementation behind its interface (DI).
builder.Services.AddSingleton<ISimpleCalculator, SimpleCalculator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Allow the Angular dev server (localhost:4200) to call this API.
const string CorsPolicy = "AllowAngularDev";
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicy, policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// Swagger UI available in all environments for easy manual testing.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(CorsPolicy);

// --- Calculator endpoints -------------------------------------------------

app.MapGet("/api/calculator/add", (int start, int amount, ISimpleCalculator calc) =>
{
    try
    {
        return Results.Ok(new CalculationResult(start, amount, "add", calc.Add(start, amount)));
    }
    catch (OverflowException)
    {
        return Results.BadRequest(new { error = "The result overflows a 32-bit integer." });
    }
});

app.MapGet("/api/calculator/subtract", (int start, int amount, ISimpleCalculator calc) =>
{
    try
    {
        return Results.Ok(new CalculationResult(start, amount, "subtract", calc.Subtract(start, amount)));
    }
    catch (OverflowException)
    {
        return Results.BadRequest(new { error = "The result overflows a 32-bit integer." });
    }
});

app.Run();

/// <summary>Response payload returned by the calculator endpoints.</summary>
public record CalculationResult(int Start, int Amount, string Operation, int Result);
