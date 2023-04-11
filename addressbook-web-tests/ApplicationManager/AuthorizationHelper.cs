using OpenQA.Selenium;
using System;

namespace addressbook_web_tests
{
    public class AuthorizationHelper : HelperBase
    {
        public AuthorizationHelper(ApplicationManager applicationManager) : base(applicationManager) {}
        public void AddressBookAuthorization(AccountData account)
        {
            if (IsAuthorized())
            {
                if(IsAuthorized(account))
                {
                    return;
                }
                LogoutFromAddressBook();
            }
            Insert(By.Name("user"), account.Username);
            Insert(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsAuthorized(AccountData account)
        {
            return IsAuthorized()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text == "(" + account.Username + ")";
        }

        public bool IsAuthorized()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public void LogoutFromAddressBook()
        {
            if (IsAuthorized())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                driver.FindElement(By.Name("user"));
            }

        }
    }
}
