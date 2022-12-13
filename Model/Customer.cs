namespace CLASSEM19.Model
{
    public class Customer : User
    {
        public string RegNumber{get;set;}
        public string Address{get;set;}
        //public decimal Wallet{get;set;}
        public string PhoneNumber{get;set;}
        public Customer(string firstName, string lastName, string email, string pin, string regNumber, string address, string phoneNumber) :  base (firstName, lastName, email, pin)
        {
            RegNumber = regNumber;
            Address = address;
            //Wallet = wallet;
            PhoneNumber = phoneNumber;
        }
    }
}