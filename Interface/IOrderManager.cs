using CLASSEM19.Menu;
using CLASSEM19.Model;

namespace CLASSEM19.Interface
{
    public interface IOrderManager
    {
        public void CreateOrder(string customerName, string goods, string deliveryAddress, string customerPhoneNumber,string customerEmail, decimal totalPrice);
        public void UpdateOrder();
        public void DeleteOrder();
        public Order GetOrder(string refNumber);
        public void GetAllOrder();
    }
}