using System;

namespace addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData(string name)
        { 
            Name = name; 
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

        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public string Id { get; set; }
    }
}
