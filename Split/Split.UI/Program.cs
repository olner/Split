using Microsoft.Extensions.DependencyInjection;
using Split.UI.Forms;
using Split.WebClient;


namespace Split.UI
{
    internal static class Program
    {
        private static IServiceProvider provider;
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
            var context = provider.GetRequiredService<ApplicationContext>();

            ApplicationConfiguration.Initialize();

            context.MainForm = provider.GetRequiredService<LoginForm>();

            Application.Run(context);
        }
        private static IServiceProvider GetProvider()
        {
            var services = new ServiceCollection();

            services.AddTransient<LoginForm>();
            services.AddTransient<RegistrationForm>();

            services.AddSingleton(sp =>
            {
                var httpClient = sp.GetRequiredService<HttpClient>();
                httpClient.BaseAddress = new Uri("http://localhost:5000/");
                //httpClient.BaseAddress = new Uri("https://olner.kiinse.me");
                return new SplitServiceApi(httpClient);
            });

            
            services.AddSingleton<ApplicationContext>();

            services.AddHttpClient();

            return services.BuildServiceProvider();
        }
    }
}