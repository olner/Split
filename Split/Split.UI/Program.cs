using Microsoft.Extensions.DependencyInjection;
using Split.WebClient;
using System.Runtime.CompilerServices;

namespace Split.UI
{
    internal static class Program
    {
        private static IServiceProvider provider;
        static ApplicationContext context;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            provider = GetProvider();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //var client = new SplitServiceApi(new HttpClient());
            context = provider.GetRequiredService<ApplicationContext>();

            ApplicationConfiguration.Initialize();

            context.MainForm = provider.GetRequiredService<LoginForm>();

            Application.Run(context);
        }
        private static IServiceProvider GetProvider()
        {
            var services = new ServiceCollection();

            services.AddTransient<LoginForm>(sp =>
            {
                var client = sp.GetRequiredService<SplitServiceApi>();
                var context = sp.GetRequiredService<ApplicationContext>(); 
                return new LoginForm(client,context);
            });
            services.AddTransient<SplitServiceApi>(sp =>
            {
                var httpClient = sp.GetRequiredService<HttpClient>();
                //var httpClientHandler = new HttpClientHandler();

                return new SplitServiceApi(httpClient);
            });

            services.AddSingleton<LoginForm>();
            services.AddSingleton<ApplicationContext>();
            services.AddSingleton<SplitServiceApi>();

            services.AddSingleton<HttpClient>();

            return services.BuildServiceProvider();
        }
    }
}