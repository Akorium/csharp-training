using System;



namespace addressbook_test_data_generator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Требуемые аргументы: <count> <filename> <format> <type>");
                return;
            }
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];
            string type = args[3];
            if (type == "groups")
            {
                GroupDataGenerator groupGenerator = new GroupDataGenerator();
                groupGenerator.GenerateGroupData(count, filename, format);
            }
            else if (type == "entries")
            {
                EntryDataGenerator entryGenerator = new EntryDataGenerator();
                entryGenerator.GenerateEntryData(count, filename, format);
            }
            else
            {
                Console.Out.Write("Unrecognized data type " + type);
            }
        }
    }
}
