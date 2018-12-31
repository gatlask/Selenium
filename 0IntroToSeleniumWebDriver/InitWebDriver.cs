using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace InitWebDriver
{
    /// <summary>
    /// This Program initialises the Webdriver Class
    /// 
    /// </summary>
    class InitWebDriver
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            IWebDriver driver = new FirefoxDriver(Environment.CurrentDirectory);
          
            //IWebDriver driver = new ChromeDriver();

            //Navigate to google page
            driver.Navigate().GoToUrl("http:www.google.com");

            String Currenttitle = driver.Title;

            Console.WriteLine(Currenttitle);

            
            Console.WriteLine(driver.Url);

            driver.Navigate().GoToUrl("http://www.motivitylabs.com");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(200);

            //Close the browser
            driver.Close();

        }
    }
}
