using LinqToDB;

namespace addressbook_web_tests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook")
        {

        }
        public ITable<GroupData> Groups => this.GetTable<GroupData>();
        public ITable<Group_EntryRelation> Group_EntryRelations => this.GetTable<Group_EntryRelation>();
        public ITable<AddressBookEntryData> Entries => this.GetTable<AddressBookEntryData>();
    }
}
