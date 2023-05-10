using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name = "address_in_groups")]
    public class Group_EntryRelation
    {
        [Column(Name = "group_id")]
        public string GroupId { get; }
        [Column(Name = "id")]
        public string EntryId { get; }
    }
}
