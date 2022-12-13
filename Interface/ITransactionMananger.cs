namespace CLASSEM20.Interface
{
    public interface ITransactionMananger
    {
        public void CreateTransaction(string customerName, string custRegNo, string email, string refNumber, decimal cashDeposit);
        public void GetAllTransaction();
        public decimal CalculateTotalTransaction();
    }
}