using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace _2024_25_Islington_1stSemBlazorMAUI
{
    internal class Program : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
