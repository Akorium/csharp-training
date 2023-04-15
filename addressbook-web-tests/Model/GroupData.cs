using System;

namespace addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData(string name)
        { 
            this.name = name; 
        }
        public bool Equals(GroupData anotherGroup)
        {
            if (Object.ReferenceEquals(anotherGroup, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, anotherGroup))
            {
                return true;
            }
            return Name == anotherGroup.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + Name;
        }

        public int CompareTo(GroupData anotherGroup)
        {
            if (Object.ReferenceEquals (anotherGroup, null))
            {
                return 1;
            }
            return Name.CompareTo(anotherGroup.Name);
        }

        public string Name
        { 
            get 
            { 
                return name; 
            }
            set 
            {
                name = value;
            }
        }

        public string Header
        {
            get
            {
                return header;
            }
            set
            { 
                header = value; 
            }
        }

        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }
    }
}
