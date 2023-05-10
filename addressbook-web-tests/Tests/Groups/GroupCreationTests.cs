using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30).Replace("'", "").Replace(@"\", "").Replace("<", ""))
                {
                    Header = GenerateRandomString(100).Replace("'", "").Replace(@"\", "").Replace("<", ""),
                    Footer = GenerateRandomString(100).Replace("'", "").Replace(@"\", "").Replace("<", "")
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromCSV()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), @"TestData", @"Groups", @"groups.csv"));
            foreach (string l in lines)
            {
                string[] parts = l.Split(';');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXML()
        {
            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"TestData", @"Groups", @"groups.xml")));
        }
        public static IEnumerable<GroupData> GroupDataFromJSON()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"TestData", @"Groups", @"groups.json")));
        }
        public static IEnumerable<GroupData> GroupDataFromExcel()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application application = new Excel.Application
            {
                Visible = true
            };
            Excel.Workbook workbook = application.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"TestData", @"Groups", @"groups.xlsx"));
            Excel.Worksheet sheet = workbook.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }
            workbook.Close();
            application.Visible = false;
            application.Quit();
            return groups;
        }

        [Test, TestCaseSource("GroupDataFromXML")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldgroups = GroupData.GetAllData();
            applicationManager.GroupHelper.Create(group);

            Assert.AreEqual(oldgroups.Count + 1, applicationManager.GroupHelper.GetGroupsCount());

            List<GroupData> newgroups = GroupData.GetAllData();
            oldgroups.Add(group);
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("'badname")
            {
                Header = "",
                Footer = ""
            };
            List<GroupData> oldgroups = GroupData.GetAllData();
            applicationManager.GroupHelper.Create(group);
            Assert.AreEqual(oldgroups.Count, applicationManager.GroupHelper.GetGroupsCount());
            List<GroupData> newgroups = GroupData.GetAllData();
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }
        [Test]
        public void TestDBConnectivity()
        {
            foreach (AddressBookEntryData entry in AddressBookEntryData.GetAllData())
            {
                Console.Out.WriteLine(entry.Deprecated);
            }
        }
    }
}
