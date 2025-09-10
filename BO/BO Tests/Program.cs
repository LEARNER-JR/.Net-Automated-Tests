

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
        /// user management/logins
        services.AddScoped<LoginPositivePage>();
        services.AddScoped<UserManagementPage>();
        services.AddScoped< UserManagementNegativePage>();
        //tariffs
        services.AddScoped< TariffPositivePage>();
        services.AddScoped< TariffNegativePage>();
        //taxes
        services.AddScoped< TaxesPositivePage>();
        services.AddScoped<TaxesNegativePage>();
        //exchange rates
        services.AddScoped<ExRatesNegativePage>();
        return services.BuildServiceProvider();
    }
}