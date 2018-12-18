using System.Collections.Generic;
using BudgetMaster.Data.Entities.Shared;

namespace BudgetMaster.Data.Entities.Access
{
    public class Profile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Phone MainPhone { get; set; }
        public Address BillingAddress { get; set; }
        public Address PhysicalAddress { get; set; }

        public ICollection<Group> OwnedGroups { get; set; }
        public ICollection<GroupAccess> Accesses { get; set; }
    }
}