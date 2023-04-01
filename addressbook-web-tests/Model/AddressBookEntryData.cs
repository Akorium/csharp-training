namespace addressbook_web_tests
{
    public class AddressBookEntryData
    {
        private string firstname;
        private string lastname;

        public AddressBookEntryData(string firstname, string lastname)
        { 
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string Firstname
        { 
            get 
            { 
                return firstname; 
            }
            set 
            {
                firstname = value;
            }
        }

        public string LastName 
        {
            get
            {
                return lastname;
            }
            set
            { 
                lastname = value; 
            }
        }
    }
}
