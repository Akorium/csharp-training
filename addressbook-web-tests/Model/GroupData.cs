using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace addressbook_web_tests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {
        }
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
        [Column(Name = "group_name")]
        public string Name { get; set; }
        [Column(Name = "group_header")]
        public string Header { get; set; }
        [Column(Name = "group_footer")]
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }
        public static List<GroupData> GetAllData()
        {
            using (AddressBookDB dB = new AddressBookDB())
            {
                return (from g in dB.Groups select g).ToList();
            }
        }
        public List<AddressBookEntryData> GetEntries()
        {
            using (AddressBookDB dB = new AddressBookDB())
            {
                return (from e in dB.Entries
                        from ger in dB.Group_EntryRelations.Where(p => p.GroupId == Id && p.EntryId == e.Id && e.Deprecated == "0000-00-00 00:00:00")
                        select e).Distinct().ToList();
            }
        }
    }
}
