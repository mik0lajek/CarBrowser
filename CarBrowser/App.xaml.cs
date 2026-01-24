using Microsoft.Extensions.Configuration;
using System;
using System.Windows;

namespace CarBrowser
{
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();


            var splash = new Windows.SplashScreen();
            splash.Show();


        }
    }
}