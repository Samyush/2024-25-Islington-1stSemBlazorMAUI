﻿using _2024_25_Islington_1stSemBlazorMAUI.Services;
using _2024_25_Islington_1stSemBlazorMAUI.Services.Interface;
using Microsoft.Extensions.Logging;

namespace _2024_25_Islington_1stSemBlazorMAUI
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

            builder.Services.AddMauiBlazorWebView();

            //Register services 
            builder.Services.AddScoped<IUserService, UserService>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
