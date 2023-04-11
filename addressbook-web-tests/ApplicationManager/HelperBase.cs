using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager applicationManager;
        public HelperBase(ApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
            driver = applicationManager.Driver;
        }
        public void Insert(By locator, string data)
        {
            if (data != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(data);
            }
        
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}