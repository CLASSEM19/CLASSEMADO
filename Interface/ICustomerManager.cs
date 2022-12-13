using CLASSEM19.Menu;
using CLASSEM19.Model;

namespace CLASSEM19.Interface
{
    public interface ICustomerManager
    {
        public void CreateCustomer(string firstName, string lastName, string email, string pin, string address, string phoneNumber);
        public void UpdateCustomer(string regNumber, string firstName, string lastName, string email, string address, string phoneNumber);
        public void DeleteCustomer();
        public Customer GetCustomer(string email);  
        public void GetAllCustomer();
        public Customer LoginCustomer(string email, string pin);
       // object GetCustomer(object email);
    }
}