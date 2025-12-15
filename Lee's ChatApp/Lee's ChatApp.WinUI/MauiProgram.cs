using LeratosChatServer1.Hubs; // matches your ChatHub namespace
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;


var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// SignalR
builder.Services.AddSignalR();

// CORS for MAUI client
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
              .SetIsOriginAllowed(_ => true);
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapControllers();
app.MapHub<ChatHub>("/chatHub");

app.Run();
