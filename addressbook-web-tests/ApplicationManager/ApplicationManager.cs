using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace addressbook_web_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected AuthorizationHelper authorizationHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected AddressBookEntryHelper addressBookEntryHelper;

        public ApplicationManager() 
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";

            authorizationHelper = new AuthorizationHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            addressBookEntryHelper = new AddressBookEntryHelper(this);
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public AuthorizationHelper AuthorizationHelper
        { 
            get 
            { 
                return authorizationHelper; 
            } 
        }
        public NavigationHelper NavigationHelper
        {
            get
            {
                return navigationHelper;
            }
        }
        public GroupHelper GroupHelper
        {
            get
            {
                return groupHelper;
            }
        }
        public AddressBookEntryHelper AddressBookEntryHelper
        {
            get
            {
                return addressBookEntryHelper;
            }
        }
    }
}
