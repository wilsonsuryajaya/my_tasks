﻿using Microsoft.Extensions.Logging;
using MyTasks.ViewModel;

namespace MyTasks
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts( fonts =>
                {
                    fonts.AddFont( "OpenSans-Regular.ttf", "OpenSansRegular" );
                    fonts.AddFont( "OpenSans-Semibold.ttf", "OpenSansSemibold" );
                    fonts.AddFont( "fa-solid-900.ttf", "FASolid" );
                } );

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
