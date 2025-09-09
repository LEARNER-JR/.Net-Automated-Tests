using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BO_Tests.Tests
{
    public class BaseTest
    {
        protected IServiceProvider ServiceProvider { get; private set; }
        protected IWebDriver Driver { get; private set; }

        [SetUp]
        public void SetUp()
        {
            ServiceProvider = new Program().ConfigureServices();
            Driver = ServiceProvider.GetRequiredService<IWebDriver>();
        }
        //[TearDown]
        //public void Teardown()
        //{
        //    if (Driver != null)
        //    {
        //        Driver.Quit(); 
        //        Driver.Dispose();
        //    }
        //}
    }
}