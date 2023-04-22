using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

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
        private static readonly ThreadLocal<ApplicationManager> applicationManager = new ThreadLocal<ApplicationManager>();

        private ApplicationManager() 
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0.05); //depends on machine performance
            baseURL = "http://localhost/addressbook";

            authorizationHelper = new AuthorizationHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            addressBookEntryHelper = new AddressBookEntryHelper(this);
        }
        ~ApplicationManager()
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
        public static ApplicationManager GetInstance()
        {
            if (!applicationManager.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.NavigationHelper.OpenAddressBookPage();
                applicationManager.Value = newInstance;               
            }
            return applicationManager.Value;

        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
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
