using addressbook_web_tests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generator
{
    internal class EntryDataGenerator
    {
        public void GenerateEntryData(int count, string filename, string format)
        {
            List<AddressBookEntryData> entries = new List<AddressBookEntryData>();
            for (int i = 0; i < count; i++)
            {
                entries.Add(new AddressBookEntryData(TestBase.GenerateRandomString(10).Replace(";", "").Replace("'", "").Replace(@"\", "").Replace("<", ""),
                    TestBase.GenerateRandomString(10).Replace(";", "").Replace("'", "").Replace(@"\", "").Replace("<", "")));
            }
            if (format == "excel")
            {
                WriteToExcel(entries, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename + "." + format);
                if (format == "csv")
                {
                    WriteToCSV(entries, writer);
                }
                else if (format == "xml")
                {
                    WriteToXML(entries, writer);
                }
                else if (format == "json")
                {
                    WriteToJSON(entries, writer);
                }
                else
                {
                    Console.Out.Write("Unrecognized format " + format);
                }
                writer.Close();
            }
        }

        private static void WriteToExcel(List<AddressBookEntryData> entries, string filename)
        {
            Excel.Application application = new Excel.Application
            {
                Visible = true
            };
            Excel.Workbook workbook = application.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            int row = 1;

            foreach (AddressBookEntryData entry in entries)
            {
                worksheet.Cells[row, 1] = entry.Firstname;
                worksheet.Cells[row, 2] = entry.Lastname;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            workbook.SaveAs(fullPath);
            workbook.Close();
            application.Visible = false;
            application.Quit();
        }

        private static void WriteToXML(List<AddressBookEntryData> entries, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<AddressBookEntryData>)).Serialize(writer, entries);
        }

        private static void WriteToCSV(List<AddressBookEntryData> entries, StreamWriter writer)
        {
            foreach (AddressBookEntryData entry in entries)
            {
                writer.WriteLine(string.Format("${0};${1}",
                    entry.Firstname, entry.Lastname));
            }
        }
        private static void WriteToJSON(List<AddressBookEntryData> entries, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(entries, Formatting.Indented));
        }
    }
}
