using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class AuthorizationHelper : HelperBase
    {
        public AuthorizationHelper(ApplicationManager applicationManager) : base(applicationManager) {}
        public AuthorizationHelper AddressBookAuthorization(AccountData account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            return this;
        }
        public AuthorizationHelper LogoutFromAddressBook()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
    }
}
