using System;
using CLASSEM19.Implementation;
using CLASSEM19.Menu;
using CLASSEM20.Implementation;

namespace CLASSEM19
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // var adminManager = new AdminManager();
            // adminManager.ReadFromFile();
            // var custManager = new CustomerManager();
            // custManager.ReadFromFile();
            // var carManager = new CarManager();
            // carManager.ReadFromFile();
            // var orderManager = new OrderManager();
            // orderManager.ReadFromFile();

            // var cust = new CustomerManager();
            // cust.CreateDataBaseTable();
            MainMenu mm = new MainMenu();
            mm.TMainMenu();
            // var transaction = new TransactionManager();
            // transaction.CreateDataBaseTable();
           

            // int value;
            // bool check = false;
            // do
            // {
            //     check = int.TryParse(Console.ReadLine(), out value);
            // } while (!check);


            // CustomerMenu cmss = new CustomerMenu();
            // //  cmss.RegisterCustomerMenu();
            //  cmss.LoginCustomerMenu();


        }
    }
}
