using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Globalization;
using System.Threading;

namespace FillSignup
{
    /// <summary>
    /// Open a test Page and fill the signup form
    /// 
    /// </summary>
    class FillSignup
    {
        static void Main(string[] args)
        {
            //            //Initialise the webdirver

            IWebDriver driver = new ChromeDriver();

            //Navigate to main page, here it is tsrts
            OpenPage(driver, "https://tsrtconline.in/oprs-web/");

            ConfirmPage(driver, "Main");
         //   Thread.Sleep(1000);

            //Open Login Page
            OpenPageByElement(driver, "eTicket Login");
            ConfirmPage(driver, "Login");
           // Thread.Sleep(1000);

            // Open Signup Page
            OpenPageByElement(driver, "SignUp");
            ConfirmPage(driver, "SignUp");
            //Thread.Sleep(1000);

            //Fill Signup Page

            //Create User;
            UserInfo usr1 = new UserInfo(); // this also initialises the values with default constructor

            FillPageSignup(driver, usr1);
            Thread.Sleep(2000);

            // Take Screen Shot of filled items 
            // or printout the page after signup
            //ITakesScreenshot ScrnShot;

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("Test.png");


            //Close the browser and command prompt
            driver.Close();
            driver.Quit();
            
        }


        private static void OpenPage(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl("https://tsrtconline.in/oprs-web/");

        }

        private static void OpenPageByElement(IWebDriver driver, string elementTxt)
        {
            IWebElement element;

            try
            {
                element = driver.FindElement(By.PartialLinkText(elementTxt));
                element.Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element is missing");
            }
        }

        private static void ConfirmPage(IWebDriver driver, string v)
        {
            // Write Code here to Confirm if the correct page has opened
            // for now just printing out the url of the page opened along with string supplied
            //Console.WriteLine(driver.Title);
            Console.WriteLine(driver.Url + "  " + v);
        }

        class UserInfo
        {
            public string loginName;
            public string fullName;
            public string email;
            public char gender;
            public DateTime txtDob;
            public double mobileNo;
            public string Nationality;
            public string address;
            public string city;
            public string state;
            public string country;
            public int zipCode;
            public string IDCardType;
            public string idNumber;
            public string issueAuthority;

            //default constructor initialises everything to test values
            public UserInfo()
            {
                this.loginName = "test";
                this.fullName = "fName";
                this.email = "tes1234t@gmail.com";
                this.gender = 'm'; // n is not selected of default
                this.txtDob = DateTime.Parse("15/08/1947");
                this.mobileNo = 8888348889;
                this.Nationality = "INDIAN";
                this.address = "this is a very long address field, can be entered in two strings";
                this.city = "Hyderabad";
                this.state = "Telangana";
                this.country = "india";
                this.zipCode = 500013;
                this.IDCardType = "DL";
                this.idNumber = "200HL456";
                this.issueAuthority = "Govt of India";
            }

        }

        private static void FillPageSignup(IWebDriver driver, UserInfo usr1)
        {
        
            IWebElement element;
            // IWebElement elmt;

            //enter Login Name
            driver.FindElement(By.Name("loginName")).SendKeys(usr1.loginName);
            
            //enter Name
            driver.FindElement(By.Name("fullName")).SendKeys(usr1.fullName);

            //enter email
            driver.FindElement(By.Name("email")).SendKeys(usr1.email);


            //enter gender
            if (usr1.gender == 'm')
            {
                driver.FindElement(By.Id("genderId")).FindElement(By.XPath(".//option[contains(text(),'MALE')]")).Click();
            }
            else
            {
                driver.FindElement(By.Id("genderId")).FindElement(By.XPath(".//option[contains(text(),'FEMALE')]")).Click();
            }

            //enter Dob
            element = driver.FindElement(By.Name("txtDob"));
            element.Click();

            element = driver.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]"));
            if (element.Displayed)
            {
                //select year
                SelectElement dSelect = new SelectElement(element.FindElement(By.ClassName("ui-datepicker-year")));
                dSelect.SelectByText(Convert.ToString(usr1.txtDob.Year));//"1956");//

                //select month
                dSelect = new SelectElement(driver.FindElement(By.ClassName("ui-datepicker-month")));
                dSelect.SelectByText(CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(usr1.txtDob.Month));//"Jun");

                //Click Date
                driver.FindElement(By.XPath($"//*[text()='{usr1.txtDob.Day}']")).Click();
            }

            //enter mobile
            driver.FindElement(By.Name("mobileNo")).SendKeys(Convert.ToString(usr1.mobileNo));

            //enter nationality ID
            SelectElement oSelect = new SelectElement(driver.FindElement(By.Name("nationalityId")));
            oSelect.SelectByText("INDIAN");

            //enter address
            element = driver.FindElement(By.Name("address1"));
            if (usr1.address.Length > Convert.ToInt32(element.GetAttribute("maxlength")))
            {
                element.SendKeys(usr1.address.Substring(0, Convert.ToInt32(element.GetAttribute("maxlength"))));
                element = driver.FindElement(By.Name("address2"));
                element.SendKeys(usr1.address.Substring(Convert.ToInt32(element.GetAttribute("maxlength"))));

            }
            else
            {
                element.SendKeys(usr1.address);
            }

            //enter city
            driver.FindElement(By.Name("city")).SendKeys(usr1.city);

            //enter state
            driver.FindElement(By.Name("stateName")).SendKeys(usr1.state);

            //enter Country
            oSelect = new SelectElement(driver.FindElement(By.Name("countryCode")));
            oSelect.SelectByText("India");

            //enter zip Code
            driver.FindElement(By.Name("zipCode")).SendKeys(Convert.ToString(usr1.zipCode));

            //enter nationality ID
            oSelect = new SelectElement(driver.FindElement(By.Name("proofTypeId")));
            oSelect.SelectByText("VOTER ID");

            //enter Login Name
            element = driver.FindElement(By.Name("idNumber"));
            element.SendKeys(Convert.ToString(usr1.idNumber));

            //enter Login Name
            element = driver.FindElement(By.Name("issueAuthority"));
            element.SendKeys(usr1.issueAuthority);
            
            
        }
    }
}


