using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Error-handling middleware FIRST
app.UseMiddleware<UserManagementAPI.Middleware.ErrorHandlingMiddleware>();

// Authentication middleware NEXT
app.UseMiddleware<UserManagementAPI.Middleware.TokenAuthenticationMiddleware>();

// Logging middleware LAST
app.UseMiddleware<UserManagementAPI.Middleware.RequestResponseLoggingMiddleware>();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();