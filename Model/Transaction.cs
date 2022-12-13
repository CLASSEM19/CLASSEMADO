using System;

namespace CLASSEM20.Model
{
    public class Transaction
    {
        public string ReceiptNo { get; set;}
        public decimal Total { get; set; }
        public DateTime DateAndTime { get; set; }
        public decimal CashDeposit { get; set; }
        public string ManPhoneNo{get; set;}
        public Transaction(string receiptNo, decimal cashDeposit, decimal total, DateTime dateAndTime, string manPhoneNo)
        {
            ReceiptNo = receiptNo;
            CashDeposit = cashDeposit;
            Total = total;
            DateAndTime = dateAndTime;
            ManPhoneNo = manPhoneNo;
        }
    }
}