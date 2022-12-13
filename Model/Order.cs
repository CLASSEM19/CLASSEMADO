namespace CLASSEM19.Model
{
    public class Order
    {
        public string RefNumber{get;set;}
        public string CustomerName {get;set;}
        public string DeliveryAddress{get;set;}
        public string CustomerPhoneNumber{get;set;}
        public string CustomerEmail{get;set;}
        public string Goods{get;set;}
        public decimal TotalPrice{get; set;}
        public Order(string refNumber, string customerName,string goods, string deliveryAddress, string customerPhoneNumber, string customerEmail, decimal totalPrice)
        {
            RefNumber = refNumber;
            CustomerName = customerName;
            DeliveryAddress = deliveryAddress;
            CustomerPhoneNumber = customerPhoneNumber;
            CustomerEmail = customerEmail;
            Goods = Goods;
            TotalPrice = totalPrice;
        }
    }
}