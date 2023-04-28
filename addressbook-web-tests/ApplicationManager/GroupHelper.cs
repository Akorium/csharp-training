using OpenQA.Selenium;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager applicationManager) : base(applicationManager) { }
        public void Create(GroupData group)
        {
            applicationManager.NavigationHelper.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }
        public void Remove(int number)
        {
            applicationManager.NavigationHelper.GoToGroupsPage();
            SelectGroup(++number);
            SubmitGroupRemoval();
            ReturnToGroupsPage();
        }
        public void Modify(GroupData group, int number)
        {
            applicationManager.NavigationHelper.GoToGroupsPage();
            SelectGroup(++number);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupsPage();
        }


        public void CheckGroup(int number)
        {
            applicationManager.NavigationHelper.GoToGroupsPage();
            if (!IsThereAnyGroup(++number))
            {
                GroupData group = new GroupData("name")
                {
                    Header = "header",
                    Footer = "footer"
                };
                Create(group);
            }
        }

        public bool IsThereAnyGroup(int number)
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + number + "]"));
        }

        public void InitGroupCreation()
        {
            driver.FindElement(By.XPath("//input[@value='New group']")).Click();
        }
        public void FillGroupForm(GroupData group)
        {
            Insert(By.Name("group_name"), group.Name);
            Insert(By.Name("group_header"), group.Header);
            Insert(By.Name("group_footer"), group.Footer);
        }

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter information']")).Click();
            groupsCache = null;
        }
        public void SelectGroup(int number)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + number + "]")).Click();
        }
        public void SubmitGroupRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete group(s)']")).Click();
            groupsCache = null;
        }
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
        public void InitGroupModification()
        {
            driver.FindElement(By.XPath("//input[@value='Edit group']")).Click();
        }
        public void SubmitGroupModification()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            groupsCache = null;
        }
        private List<GroupData> groupsCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupsCache == null)
            {
                groupsCache = new List<GroupData>();
                applicationManager.NavigationHelper.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupsCache.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
                string allGroupsNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupsNames.Split('\n');
                int shift = groupsCache.Count - parts.Length;
                for (int i = 0; i < groupsCache.Count; i++)
                {
                    groupsCache[i].Name = i < shift ? "" : parts[i - shift].Trim();
                }
            }
            return new List<GroupData>(groupsCache);
        }

        public int GetGroupsCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
