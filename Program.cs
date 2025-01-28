using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;
using System;


var builder = WebApplication.CreateBuilder(args);

// Set the app to listen on HTTP (port 5176)
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(5176);  // Listen on HTTP only
});

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// In-memory storage for users
var users = new List<User>();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandlingMiddleware();
app.UseAuthenticationMiddleware();  // Authentication middleware to validate tokens
app.UseLoggingMiddleware();         // Logging middleware to log requests/responses
app.UseAuthorization();
app.MapControllers();

// Define the User Controller
app.MapGet("/User", () =>
{
    try
    {
        return Results.Ok(users);  // Return the users list (empty array on first load)
    }
    catch (Exception ex)
    {
        return Results.Problem($"Internal server error: {ex.Message}");
    }
});

app.MapPost("/User", (User user) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(user.Name))
        {
            return Results.BadRequest("Name is required.");
        }
        if (string.IsNullOrWhiteSpace(user.Email))
        {
            return Results.BadRequest("Email is required.");
        }
        if (!user.Email.Contains("@"))
        {
            return Results.BadRequest("Invalid email format.");
        }

        user.Id = users.Count + 1;
        users.Add(user);
        return Results.Created($"/User/{user.Id}", user);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Internal server error: {ex.Message}");
    }
});

app.MapGet("/User/{id}", (int id) =>
{
    try
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return Results.NotFound("User not found.");
        }
        return Results.Ok(user);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Internal server error: {ex.Message}");
    }
});

app.MapPut("/User/{id}", (int id, User updatedUser) =>
{
    try
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return Results.NotFound("User not found.");
        }

        if (string.IsNullOrWhiteSpace(updatedUser.Name))
        {
            return Results.BadRequest("Name is required.");
        }

        user.Name = updatedUser.Name;

        if (!string.IsNullOrWhiteSpace(updatedUser.Email))
        {
            if (!updatedUser.Email.Contains("@"))
            {
                return Results.BadRequest("Invalid email format.");
            }
            user.Email = updatedUser.Email;
        }

        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Internal server error: {ex.Message}");
    }
});

app.MapDelete("/User/{id}", (int id) =>
{
    try
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return Results.NotFound("User not found.");
        }

        users.Remove(user);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Internal server error: {ex.Message}");
    }
});

app.Run();

// User model
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
