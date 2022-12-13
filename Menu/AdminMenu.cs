using System;
using System.Collections.Generic;
using CLASSEM19.Implementation;
using CLASSEM19.Interface;
using CLASSEM19.Model;
using CLASSEM20.Implementation;
using CLASSEM20.Interface;


namespace CLASSEM19.Menu
{
    public class AdminMenu
    {
        public static List<AdminMenu> listOfAdminMeans = new List<AdminMenu>();
        IAdminManager adminManager = new AdminManager();
        ICustomerManager customerManager = new CustomerManager();
        IOrderManager orderManager = new OrderManager();
        ITransactionMananger _TransactionManager = new TransactionManager();
        MainMenu mainMenu = new MainMenu();
        ICarManager carManager = new CarManager();
        public void AdminMainMenu()
        {
            Console.WriteLine("\nEnter 1 to Register Admin\nEnter 2 to Login as Admin\nEnter 0 to Main Menu\n");
            int choice;
            bool check = false;
            do
            {
                check = int.TryParse(Console.ReadLine(), out choice);
            } while (!check);
            if (choice == 1)
            {
                RegisterAdminMenu();
            }
            else if (choice == 2)
            {
                LoginAdminMenu();
            }
            else if (choice == 0)
            {
                mainMenu.TMainMenu();
            }
            else
            {
                Console.Beep();
                Console.WriteLine("\n\tINVALID INPUT");
                AdminMainMenu();
            }
        }

        public void RegisterAdminMenu()
        {
            Console.Write("\nEnter First Name: ");
            string fName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lName = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Pin: ");
            string pin = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter Post: ");
            string post = Console.ReadLine();

            adminManager.CreateAdmin(fName, lName, email, pin, phoneNumber, post);
            AdminMainMenu();
        }

        public void LoginAdminMenu()
        {
            Console.Write("\nEnter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Pin: ");
            string pin = Console.ReadLine();
            Admin adm = adminManager.Login(email, pin);
            if (adm != null && adm.Email == email && adm.Pin == pin)
            {
                Console.Beep();
                Console.WriteLine($"\n\tWELCOME {adm.FirstName} LOGIN SUCCESSFUL!");
                AdminSubMenu();
            }
            else
            {
                Console.Beep();
                Console.WriteLine("\n\tINVALID LOGIN INPUT!");
                LoginAdminMenu();
            }

        }

        public void AdminSubMenu()
        {
            Console.WriteLine("\nEnter 1 to register Car\nEnter 2 to update Car\nEnter 3 to Veiw all Cars\nEnter 4 to delete a Car\nEnter 5 to Get Car\nEnter 6 to Get Customer\nEnter 7 to Veiw All Customer\nEnter 8 to Delete Customer Account\nEnter 9 to Veiw All Admin\nEnter 10 to Update Admin\nEnter 11 to Delete Admin\nEnter 12 to Veiw Order\nEnter 13 to View All Order\nEnter 14 to Delete Order\nEnter 15 to Get All Transaction\nEnter 0 to Main Menu\n");

            int choice;
            bool check = false;
            do
            {
                check = int.TryParse(Console.ReadLine(), out choice);
            } while (!check);
            if (choice == 1)
            {
                RegisterCar();
            }
            else if (choice == 2)
            {
                carManager.UpdateCar();
            }
            else if (choice == 3)
            {
                Console.Beep();
                Console.WriteLine("\nREf NUMBER\t\tCAR NAME\t\t\t\tCAR COLOR\t\tCAR PRICE\t\tCAR ENGINE TYPE");
                carManager.GetAllCars();
            }
            else if (choice == 4)
            {
                carManager.DeleteCar();
            }
            else if (choice == 5)
            {
                GetCar();
            }
            else if (choice == 6)
            {
                GetCustomer();
            }
            else if (choice == 7)
            {
                Console.Beep();
                Console.WriteLine("\nCUSTOMER REGNO\t\tCustomer Name\t\tCustomer Email\t\tCustomer Address\t\tPhone Number");
                customerManager.GetAllCustomer();
            }
            else if (choice == 8)
            {
                customerManager.DeleteCustomer();
            }
            else if (choice == 9)
            {
                Console.Beep();
                Console.WriteLine("\nID\t\tFULL NAME\t\tPOST\t\tEMAIL\t\tPHONE NUMBER");
                adminManager.GetAllAdmin();
            }
            else if (choice == 10)
            {

                Console.Write("\nEnter First Name Updating to: ");
                string firstName = Console.ReadLine().Trim();
                Console.Write("\nEnter Last Name Updating to: ");
                string lastName = Console.ReadLine().Trim();
                Console.Write("\nEnter Email Updating to: ");
                string email = Console.ReadLine().Trim();
                Console.Write("\nEnter Phone Number Updating to: ");
                string phoneNumber = Console.ReadLine().Trim();
                adminManager.UpdateAdmin(firstName, lastName, email, phoneNumber);
            }
            else if (choice == 11)
            {
                adminManager.DeleteAdmin();
            }
            else if (choice == 12)
            {
                GetOrder();               
            }
            else if (choice == 13)
            {
                Console.Beep();
                Console.WriteLine("\nREFRENCE NO.\t\tCUSTOMER NAME\t\tGOODS BOUGTH\t\tADDRESS\t\tCUSTOMER EMAIL\t\tPHONE NUMBER");
                orderManager.GetAllOrder();
            }
            else if (choice == 14)
            {
                orderManager.DeleteOrder();
            }
            else if (choice == 15)
            {
                Console.Beep();
                Console.WriteLine("RECEIPT NO\tCUSTOMER NAME\tCUSTOMER EMAIL\tCUSTOMER REGNO\tCAR NAME\tTOTAL AMOUNT\tAMOUNT PAID\tMANAGEMENT NO\tCUSTOMER NO\tDATEANDTIME");
                _TransactionManager.GetAllTransaction();
            }
            else if (choice == 0)
            {
                AdminMainMenu();
            }
            else
            {
                Console.Beep();
                Console.WriteLine("\n\tINVALID INPUT");
                AdminSubMenu();
            }
        }
        public void RegisterCar()
        {
            Console.Write("\nEnter Car Name: ");
            string carName = Console.ReadLine();
            Console.Write("Enter Car Color: ");
            string carColor = Console.ReadLine();
            Console.Write("Enter Car Price: ");
            decimal carPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Engine Type: ");
            string carEngineType = Console.ReadLine();

            ICarManager _carManager = new CarManager();
            carManager.CreateCar(carName, carColor, carPrice, carEngineType);
            AdminSubMenu();
        }

        public void GetCar()
        {
            Console.Write("\nGet Car Refrence Number: ");
            string refNumber = Console.ReadLine();
            var car = carManager.GetCar(refNumber);
            Console.Beep();
            Console.WriteLine($"\nCar Name\t Car Color\t Car Price\t Engine Type\t ");
            Console.WriteLine($"{car.CarName}\t {car.CarColor}\t {car.CarPrice}\t {car.CarEngineType}");
            AdminSubMenu();
        }

        public void GetCustomer()
        {
            Console.Write("\nEnter Customer Email: ");
            string email = Console.ReadLine();
            ICustomerManager _customerManager = new CustomerManager();
            _customerManager.GetCustomer(email);
            AdminSubMenu();
        }
        public void GetOrder()
        {
            Console.Write("\nEnter Other Ref Number: ");
            string refNumber = Console.ReadLine(); 
            Console.WriteLine("REFRENCE NO.\t\tCUSTOMER NAME\t\tGOODS BOUGHT\t\tADDRESS\t\tCUSTOMER EMAIL\t\tPHONE NUMBER");
            IOrderManager _orderManager = new OrderManager();
            var odr = _orderManager.GetOrder(refNumber);
            Console.WriteLine($"{odr.RefNumber}\t\t{odr.CustomerName}\t\t{odr.Goods}\t\t{odr.DeliveryAddress}\t\t{odr.CustomerEmail}\t\t{odr.CustomerPhoneNumber}");
            AdminSubMenu();
        }

    }
}