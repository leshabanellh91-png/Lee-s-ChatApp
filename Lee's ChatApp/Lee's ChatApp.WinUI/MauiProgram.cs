using LeratosChatServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Controllers (optional)
builder.Services.AddControllers();

// SignalR
builder.Services.AddSignalR();

// CORS for MAUI client
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyMethod()
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
