using System;
using System.Collections.Generic;
using CLASSEM19.Implementation;
using CLASSEM19.Interface;
using CLASSEM19.Model;
using CLASSEM20.Implementation;
using CLASSEM20.Interface;

namespace CLASSEM19.Menu
{
    public class CustomerMenu
    {
        public static List<CustomerMenu> listOfCustomerMeans = new List<CustomerMenu>();
        ICustomerManager customerManager = new CustomerManager();
        ICarManager carManager = new CarManager();
        IOrderManager orderManager = new OrderManager();
        ITransactionMananger _TransactionManager = new TransactionManager();
        MainMenu mainMenu = new MainMenu();


        public void CustomerMainMenu()
        {
            bool isPrev = false;
            while (!isPrev)
            {
                Console.WriteLine("\nEnter 1 to Register\nEnter 2 to Login\nEnter 0 to Main Menu\n");
                int choice;
                bool check = false;
                do
                {
                    check = int.TryParse(Console.ReadLine(), out choice);
                } while (!check);
                if (choice == 1)
                {
                    RegisterCustomerMenu();
                }
                else if (choice == 2)
                {
                    LoginCustomerMenu();
                }
                else if (choice == 0)
                {
                    isPrev = true;
                }
                else
                {
                    Console.Beep();
                    Console.WriteLine("\n\tINVALID INPUT");
                }
            }
        }
      
        public void RegisterCustomerMenu()
        {
            Console.Write("\nEnter First Name: ");
            string fName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lName = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Pin: ");
            string pin = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            customerManager.CreateCustomer(fName, lName, email, pin, address, phoneNumber);
        }

        public void LoginCustomerMenu()
        {
            Console.Write("\nEnter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Pin: ");
            string pin = Console.ReadLine();
            Customer cust = customerManager.LoginCustomer(email, pin);
            if (cust == null )
            {
                Console.Beep();   
                Console.WriteLine("\n\tLOGIN SUCCESSFUL!");
                CustomerSubMenu();
            }
            else
            {
                Console.Beep();
                Console.WriteLine("\n\tINVALID LOGIN INPUT");
                LoginCustomerMenu();
            }
        }

        public void CustomerSubMenu()
        {
            bool isPrev = false;
            while (!isPrev)
            {
                Console.WriteLine("\nEnter 1 to Check the Available  Car\nEnter 2 to Create Order\nEnter 3 to Update your Order\nEnter 4 to Delete Order\nEnter 5 to Make Payment\nEnter 0 to Main Menu\n");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Beep();
                    Console.WriteLine("\nREf NUMBER\t\tCAR NAME\t\tCAR COLOR\t\tCAR PRICE\t\tCAR ENGINE TYPE");
                    carManager.GetAllCars();
                }
                else if (choice == 2)
                {
                    CreateOrder();
                }
                else if (choice == 3)
                {
                    orderManager.UpdateOrder();
                }
                else if (choice == 4)
                {
                    orderManager.DeleteOrder();
                }
                else if (choice == 5)
                {
                    MakeCarPayment();
                }
                else if (choice == 0)
                {
                    isPrev = true;
                }
                else
                {
                    Console.Beep();
                    Console.WriteLine("\n\tINVALID INPUT");
                }
            }
        }
        public void CreateOrder()
        {
            Console.Write("\nEnter Customer Name: ");
            string custName = Console.ReadLine();
            Console.Write("Enter  Car Name & Ref. Number: ");
            string goods = Console.ReadLine();
            Console.Write("Enter Address: ");
            string deliveryAddress = Console.ReadLine();
            Console.Write("Enter Phonenumber: ");
            string custPhoneNumber = Console.ReadLine();
            Console.Write("Enter Email: ");
            string customerEmail = Console.ReadLine();
            Console.Write("Enter Total Price: ");
            decimal totalPrice = decimal.Parse(Console.ReadLine());

            orderManager.CreateOrder(custName, goods, deliveryAddress, custPhoneNumber, customerEmail, totalPrice);

        }
        public void MakeCarPayment()
        {
            System.Console.Write("\nEnter Customer Name: ");
            var customerName = Console.ReadLine();
            System.Console.Write("Enter Customer Reg No.: ");
            var custRegNo = Console.ReadLine();
            System.Console.Write("Enter Customer Email: ");
            var email = Console.ReadLine();
            System.Console.Write("Enter Car RefNo: ");
            var refNumber = Console.ReadLine();
            // System.Console.Write("Amount to Pay: ");
            // var total = Console.ReadLine();
            System.Console.Write("Cash you want to Deposite: ");
            decimal cashDeposit = decimal.Parse(Console.ReadLine());
            _TransactionManager.CreateTransaction(customerName, custRegNo, email, refNumber, cashDeposit);
        }

    }
}