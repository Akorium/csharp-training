using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddressBookEntryCreationTests : EntryTestBase
    {
        public static IEnumerable<AddressBookEntryData> RandomEntryDataProvider()
        {
            List<AddressBookEntryData> entries = new List<AddressBookEntryData>();
            for (int i = 0; i < 5; i++)
            {
                string firstname = GenerateRandomString(30).Replace("'", "").Replace(@"\", "").Replace("<", "");
                string lastname = GenerateRandomString(30).Replace("'", "").Replace(@"\", "").Replace("<", "");
                entries.Add(new AddressBookEntryData(firstname, lastname));
            }
            return entries;
        }
        public static IEnumerable<AddressBookEntryData> EntryDataFromCSV()
        {
            List<AddressBookEntryData> entries = new List<AddressBookEntryData>();
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), @"TestData", @"Entries", @"entries.csv"));
            foreach (string l in lines)
            {
                string[] parts = l.Split(';');
                entries.Add(new AddressBookEntryData(parts[0], parts[1]));
            }
            return entries;
        }
        public static IEnumerable<AddressBookEntryData> EntryDataFromXML()
        {
            return (List<AddressBookEntryData>)
                new XmlSerializer(typeof(List<AddressBookEntryData>))
                .Deserialize(new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"TestData", @"Entries", @"entries.xml")));
        }
        public static IEnumerable<AddressBookEntryData> EntryDataFromJSON()
        {
            return JsonConvert.DeserializeObject<List<AddressBookEntryData>>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"TestData", @"Entries", @"entries.json")));
        }
        public static IEnumerable<AddressBookEntryData> EntryDataFromExcel()
        {
            List<AddressBookEntryData> entries = new List<AddressBookEntryData>();
            Excel.Application application = new Excel.Application
            {
                Visible = true
            };
            Excel.Workbook workbook = application.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"TestData", @"Entries", @"entries.xlsx"));
            Excel.Worksheet sheet = workbook.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                entries.Add(new AddressBookEntryData()
                {
                    Firstname = range.Cells[i, 1].Value,
                    Lastname = range.Cells[i, 2].Value
                });
            }
            workbook.Close();
            application.Visible = false;
            application.Quit();
            return entries;
        }

        [Test, TestCaseSource("EntryDataFromJSON")]
        public void AddressBookEntryCreationTest(AddressBookEntryData addressBookEntryData)
        {
            List<AddressBookEntryData> oldEntries = AddressBookEntryData.GetAllData();
            applicationManager.AddressBookEntryHelper.Create(addressBookEntryData);
            List<AddressBookEntryData> newEntries = AddressBookEntryData.GetAllData();
            oldEntries.Add(addressBookEntryData);
            oldEntries.Sort();
            newEntries.Sort();
            Assert.AreEqual(oldEntries, newEntries);
        }
    }
}
