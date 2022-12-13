using System;
using CLASSEM19.Implementation;
using CLASSEM19.Interface;

namespace CLASSEM19.Menu
{
    public class OrderMenu
    {
         IOrderManager orderManager = new OrderManager();

         public void OrderMainMenu()
        {
            Console.WriteLine("\nEnter 1 to register\nEnter 2 to login");
            int choice = int.Parse(Console.ReadLine());
            if(choice == 1)
            {
                RegisterOrderMenu();
            }
            // else if(choice == 2)
            // {
            //     LoginOrderMenu();
            // }
            else
            {
                Console.WriteLine("\nInvalid Input");
            }
        }

        public void RegisterOrderMenu()
        {
            Console.Write("\nEnter your customer name: ");
            string custName = Console.ReadLine();
            Console.Write("\nEnter the Goods Bought with Ref. Number: ");
            string goods = Console.ReadLine();
            Console.Write("Enter your  deliveryAddress: ");
            string deliveryAddress = Console.ReadLine();
            Console.Write("Enter your customer phonenumber: ");
            string custPhoneNumber = Console.ReadLine();
            Console.Write("Enter your customer email: ");
            string custEmail = Console.ReadLine();
            Console.Write("Enter your total price: ");
            decimal totalPrice = decimal.Parse(Console.ReadLine());

            orderManager.CreateOrder(custName, goods, deliveryAddress, custPhoneNumber, custEmail, totalPrice);
            OrderMainMenu();
        }

        // public void LoginOrderMenu()
        // {
        //     Console.Write("Enter your email: ");
        //     string email = Console.ReadLine();
        //     Console.Write("Enter your pin: ");
        //     int pin = int.Parse(Console.ReadLine());
        //     OrderMenu ord = orderManager.Login(email, pin);
        //     if(ord != null)
        //     {
        //         Console.WriteLine("login successful");
        //         OrderSubMenu();
        //     }
        //     else
        //     {
        //         Console.WriteLine("wrong email or pin");
        //     }

        // } 
    }
}