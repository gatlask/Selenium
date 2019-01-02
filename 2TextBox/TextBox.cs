using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextBox
{
    class TextBox
    {
        static void Main(string[] args)
        {
            //Initialise the webdirver

            IWebDriver driver = new ChromeDriver();

            //Navigate to google page
            driver.Navigate().GoToUrl("http://google.com");

            String Currenttitle = driver.Title;

            Console.WriteLine(Currenttitle);
            Console.WriteLine(driver.Url);

            // This Programs checks all the types of locators available in google page

            //Create an element 
            IWebElement element;

            //public static By ClassName(string classNameToFind);

            // try catch block for getting elements
            try
            {
                //Enter Name
                element = driver.FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div/div[1]/div/div[1]/input"));
             //   element.Click();
                element.SendKeys("Hello this is a sample text entry");
                Console.WriteLine("After Sample text entry");
                Thread.Sleep(1000);

                element.Click();
                Console.WriteLine("After Click");
                Thread.Sleep(1000);

                //element.Click();
                Console.WriteLine(element.GetAttribute("value")+"Text Box Value");
                Thread.Sleep(1000);

                element.Clear();
                Console.WriteLine("After Clear");
                Thread.Sleep(1000);

                element.SendKeys("Hello C#");
                Console.WriteLine("After text entry");
                Thread.Sleep(1000);

                element.Submit();
                Console.WriteLine("After Submit");
                Thread.Sleep(1000);


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element is missing");
            }

         
            Thread.Sleep(2000);


            //Close the browser
            driver.Close();


        }
    }
}


