using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LocatorTypes
{
    class LocatorTypes
    {
        /// <summary>
        /// This program checks the various types of locators available in selenium 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Initialise the webdirver

            IWebDriver driver = new ChromeDriver();

            //Navigate to google page
            driver.Navigate().GoToUrl("http:www.facebook.com");

            String Currenttitle = driver.Title;

            Console.WriteLine(Currenttitle);
            Console.WriteLine(driver.Url);

            // This Programs checks all the types of locators available in google page

            //Create an element 
            IWebElement element;

            //public static By ClassName(string classNameToFind);
            #region ClassName

            //
            // Summary:
            //     Gets a mechanism to find elements by their CSS class.
            //
            // Parameters:
            //   classNameToFind:
            //     The CSS class to find.
            //
            // Returns:
            //     A OpenQA.Selenium.By object the driver can use to find the elements.
            //
            // Remarks:
            //     If an element has many classes then this will match against each of them. For
            //     example if the value is "one two onone", then the following values for the className
            //     parameter will match: "one" and "two".
            //
            #endregion
            // public static By CssSelector(string cssSelectorToFind);
            #region CssSelector

            // Summary:
            //     Gets a mechanism to find elements by their cascading style sheet (CSS) selector.
            //
            // Parameters:
            //   cssSelectorToFind:
            //     The CSS selector to find.
            //
            // Returns:
            //     A OpenQA.Selenium.By object the driver can use to find the elements.
            #endregion
            //public static By Id(string idToFind);
            #region Id
            //
            // Summary:
            //     Gets a mechanism to find elements by their ID.
            //
            // Parameters:
            //   idToFind:
            //     The ID to find.
            //
            // Returns:
            //     A OpenQA.Selenium.By object the driver can use to find the elements.
            #endregion
            //public static By LinkText(string linkTextToFind);
            #region Linktext
            //
            // Summary:
            //     Gets a mechanism to find elements by their link text.
            //
            // Parameters:
            //   linkTextToFind:
            //     The link text to find.
            //
            // Returns:
            //     A OpenQA.Selenium.By object the driver can use to find the elements.
            #endregion
            //public static By Name(string nameToFind);
            #region Name
            //
            // Summary:
            //     Gets a mechanism to find elements by their name.
            //
            // Parameters:
            //   nameToFind:
            //     The name to find.
            //
            // Returns:
            //     A OpenQA.Selenium.By object the driver can use to find the elements.
            #endregion
            //public static By PartialLinkText(string partialLinkTextToFind);
            #region PartialLinkText
            //
            // Summary:
            //     Gets a mechanism to find elements by a partial match on their link text.
            //
            // Parameters:
            //   partialLinkTextToFind:
            //     The partial link text to find.
            //
            // Returns:
            //     A OpenQA.Selenium.By object the driver can use to find the elements.
            #endregion
            //public static By TagName(string tagNameToFind);
            #region TagName
            //
            // Summary:
            //     Gets a mechanism to find elements by their tag name.
            //
            // Parameters:
            //   tagNameToFind:
            //     The tag name to find.
            //
            // Returns:
            //     A OpenQA.Selenium.By object the driver can use to find the elements.
            #endregion
            //public static By XPath(string xpathToFind);
            #region XPath
            //
            // Summary:
            //     Gets a mechanism to find elements by an XPath query. When searching within a
            //     WebElement using xpath be aware that WebDriver follows standard conventions:
            //     a search prefixed with "//" will search the entire document, not just the children
            //     of this current node. Use ".//" to limit your search to the children of this
            //     WebElement.
            //
            // Parameters:
            //   xpathToFind:
            //     The XPath query to use.
            //
            // Returns:
            //     A OpenQA.Selenium.By object the driver can use to find the elements.
            #endregion

            try
            {

                if (driver.FindElement(By.ClassName("inputtext")).Displayed)
                {
                    Console.WriteLine("Element inputtext by Class Name is Present and Displayed");
                }

                element = driver.FindElement(By.CssSelector("#email"));

                if (element.Displayed)
                {
                    Console.WriteLine("Element # email by Css Selector is Present and Displayed");
                    Console.WriteLine(element.Size);
                }

                element = driver.FindElement(By.Id("email"));

                if (element.Displayed)
                {
                    Console.WriteLine("Element email by ID is Present and Displayed");
                    Console.WriteLine(element.Size);
                }
             //   element = driver.FindElement(By.LinkText("https://www.facebook.com/"));

                //< a href = "https://www.facebook.com/" title = "Go to Facebook home" >< i class="fb_logo img sp_eMsi9g_CT6u sx_0e8c0a"><u>Facebook</u></i></a>
                if (element.Displayed)
                {
                    Console.WriteLine("Element # email by Css Selector is Present and Displayed");
                    Console.WriteLine(element.Size);
                }
                element = driver.FindElement(By.Name("email"));

                if (element.Displayed)
                {
                    Console.WriteLine("Element email  by name is Present and Displayed");
                    Console.WriteLine(element.Size);
                }
                element = driver.FindElement(By.PartialLinkText("facebook"));

                if (element.Displayed)
                {
                    Console.WriteLine("Element # email by Css Selector is Present and Displayed");
                    Console.WriteLine(element.Size);
                }
                element = driver.FindElement(By.TagName("a")); //checking if any links are present , any tag can be searched

                if (element.Displayed)
                {
                    Console.WriteLine("Link to external element is present and it is");
                    Console.WriteLine(element.Text);
                }
                element = driver.FindElement(By.XPath("//*[@id=\"u_0_11\"]")); //Checking login form
                // //*[@id="u_0_11"]

                if (element.Displayed)
                {
                    Console.WriteLine("Element //*[@id=\"u_0_11\"] by Xpath is Present and Displayed");
                    Console.WriteLine(element.Size);
                }


                #region try catch
                // try catch block for getting elements
                //try
                //{
                //    //Enter Name
                //    element = driver.FindElement(By.Id("email"));


                //    Thread.Sleep(3000);
                #endregion
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element is missing");
            }





            Thread.Sleep(5000);


            //Close the browser
            driver.Close();

        }
    }

}
