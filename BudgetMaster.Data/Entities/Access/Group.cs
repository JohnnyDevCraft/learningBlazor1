using System;
using System.Collections.Generic;
using BudgetMaster.Data.Entities.Shared;

namespace BudgetMaster.Data.Entities.Access
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public Profile CreatedBy { get; set; }
        public int CreatedById { get; set; }
        public Address MailingAddress { get; set; }
        public Address PhysicalAddress { get; set; }
        public Address DebtAddress { get; set; }
        public Phone MainPhone { get; set; }

        public ICollection<GroupAccess> Accesses { get; set; }
    }
}