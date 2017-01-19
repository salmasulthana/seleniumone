using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumone
{
   public class gmailpom
    {
        public gmailpom()
        {
            PageFactory.InitElements(globalWebDriver.driver, this);
        }

        [FindsBy(How =How.Id,Using ="Email")]
        public IWebElement username { get; set; }

        [FindsBy(How =How.Id,Using = "next")]
        public IWebElement next_button { get; set; }

        [FindsBy(How =How.Name,Using = "Passwd")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.Id,Using = "signIn")]
        public IWebElement SignIn { get; set; }

    }
}
