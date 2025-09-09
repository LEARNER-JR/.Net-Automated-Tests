

using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
public class Program
{
    public IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        // Register your services here
        services.AddSingleton<IWebDriver>(sp =>
        {
            var options = new OpenQA.Selenium.Chrome.ChromeOptions();
            options.AddArgument("--start-maximized");
            return new OpenQA.Selenium.Chrome.ChromeDriver(options);
        });

        /// add the pages
        services.AddScoped<LoginPositivePage>();
        services.AddScoped<UserManagementPage>();
        services.AddScoped< UserManagementNegativePage>();
        return services.BuildServiceProvider();
    }
}