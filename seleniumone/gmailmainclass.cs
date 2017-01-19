using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumone
{
    [TestFixture]
    class gmailmainclass
    {

        //private string baseURL = "http://www.gmail.com";
        // public IWebDriver driver;
        private string baseURL;
        string projectpath = GetProjectFolder.getpath();

        [SetUp]
        public void setup()
        {

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\ASR\Documents\Visual Studio 2015\Projects\seleniumDriver", "geckodriver.exe");
            globalWebDriver.driver = new FirefoxDriver(service);
            System.Threading.Thread.Sleep(10000);
            globalWebDriver.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }


        [Test]

        [TestCaseSource(typeof(ExcelCalls), "getValues")]
        public void GmailLogin(ExcelCalls a)
        {


            gmailpom page = new gmailpom();
            globalWebDriver.driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
            globalWebDriver.driver.Navigate().GoToUrl("https://accounts.google.com/ServiceLogin?service=mail&passive=true&rm=false&continue=https://mail.google.com/mail/&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1#identifier");
            page.username.SendKeys(a.username);
            page.next_button.Click();
            //globalWebDriver.driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
            page.password.SendKeys(a.password);
            //globalWebDriver.driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
            page.SignIn.Click();



        }

        public void destroy()
        {
            try
            {
                globalWebDriver.driver.Quit();
            }
            catch (Exception)
            {
                Console.WriteLine("Error in closing firefox");
            }
        }
    }
    }
