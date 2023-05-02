using addressbook_web_tests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generator
{
    internal class GroupDataGenerator
    {
        public void GenerateGroupData(int count, string filename, string format)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10).Replace(";", "").Replace("'", "").Replace(@"\", "").Replace("<", ""))
                {
                    Header = TestBase.GenerateRandomString(10).Replace(";", "").Replace("'", "").Replace(@"\", "").Replace("<", ""),
                    Footer = TestBase.GenerateRandomString(10).Replace(";", "").Replace("'", "").Replace(@"\", "").Replace("<", "")
                });
            }
            if (format == "excel")
            {
                WriteToExcel(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename + "." + format);
                if (format == "csv")
                {
                    WriteToCSV(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteToXML(groups, writer);
                }
                else if (format == "json")
                {
                    WriteToJSON(groups, writer);
                }
                else
                {
                    Console.Out.Write("Unrecognized format " + format);
                }
                writer.Close();
            }
        }

        private static void WriteToExcel(List<GroupData> groups, string filename)
        {
            Excel.Application application = new Excel.Application
            {
                Visible = true
            };
            Excel.Workbook workbook = application.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            int row = 1;

            foreach (GroupData group in groups)
            {
                worksheet.Cells[row, 1] = group.Name;
                worksheet.Cells[row, 2] = group.Header;
                worksheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            workbook.SaveAs(fullPath);
            workbook.Close();
            application.Visible = false;
            application.Quit();
        }

        private static void WriteToXML(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        private static void WriteToCSV(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(string.Format("${0};${1};${2}",
                    group.Name, group.Header, group.Footer));
            }
        }
        private static void WriteToJSON(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
        }
    }
}
