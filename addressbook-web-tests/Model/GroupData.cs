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
            return !(anotherGroup is null) && (ReferenceEquals(this, anotherGroup) || Name == anotherGroup.Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + Name + ";\nheader= " + Header + ";\nFooter=" + Footer;
        }

        public int CompareTo(GroupData anotherGroup)
        {
            return anotherGroup is null ? 1 : Name.CompareTo(anotherGroup.Name);
        }

        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public string Id { get; set; }
    }
}
