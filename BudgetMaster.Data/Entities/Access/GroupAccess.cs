namespace BudgetMaster.Data.Entities.Access
{
    public class GroupAccess
    {
        public int Id { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public bool FullAccess { get; set; }
    }
}