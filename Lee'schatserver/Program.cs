using Microsoft.AspNetCore.SignalR.Client; // SignalR client namespace
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace YourAppNamespace
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Register HubConnection as singleton
            builder.Services.AddSingleton<HubConnection>(s =>
            {
                // Make sure your server is running at this URL
                var connection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:5001/chathub")
                    .WithAutomaticReconnect()
                    .Build();

                return connection;
            });

            return builder.Build();
        }
    }
}
