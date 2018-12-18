namespace BudgetMaster.Data.Entities.Shared
{
    public class Phone
    {
        public string Type { get; set; }
        public string AreaCode { get; set; }
        public string Number { get; set; }
        public string Extension { get; set; }
        public bool Verified { get; set; }
    }
}