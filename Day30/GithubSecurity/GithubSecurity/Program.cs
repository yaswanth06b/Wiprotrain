using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "GitHub";
}).AddCookie("Cookies").AddGitHub("GitHub", options =>
{
    options.ClientId = "Ov23liB5n7KMaMryJj5d";
    options.ClientSecret = "365918a4885b1c1926d58eab8aac80cb06370887";
    //options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
    //options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
    options.Scope.Add("user:email");
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/", async (HttpContext context) =>
{
    if (context.User.Identity?.IsAuthenticated ?? false)
    {
        var name = context.User.Identity.Name ?? "Unknown User";
        var email = context.User.Claims.FirstOrDefault(c => c.Type == "email")?.Value ?? "No Email";
        return Results.Ok($"Hello {name}, How are you? Your email: {email}");
    }
    else
    {
        return Results.Challenge(
            new AuthenticationProperties
            {
                RedirectUri = "/"
            },
            new[] { "GitHub" }
        );
    }
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
