namespace ExpensesTracker.Models.RequestModels
{
    public class EditAccountModel
    {
        public int Id { get; set; }
        public decimal InitialBalance { get; set; }
        public string Name { get; set; }
    }
}
