using System;

namespace CLASSEM19.Menu
{
    public class MainMenu
    {
        public void TMainMenu()
        {
            Console.WriteLine("\n########################################");
            Console.WriteLine("## WELCOME TO CLASSEM SUPERCAR OUTLET ##");
            Console.WriteLine("########################################");
            Console.WriteLine("MOTTO: ....ELEGANCY WITH SIMPLICITY.....");
            Console.WriteLine("...........BEST QUALITY GUARANTEED......");

            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("\nEnter 1 as Admin\nEnter 2 as Customer\nEnter 0 to Exit\n");
                int opt;
                bool check = false;
                do
                {
                    check = int.TryParse(Console.ReadLine(), out opt);
                } while (!check);

                if (opt == 1)
                {
                    Console.Write("\nENTER PASSKEY TO ACCESS THIS FEATURE: ");
                    string passKey = Console.ReadLine();
                    if(passKey == "CLM")
                    {
                        Console.Beep();
                        Console.WriteLine("\n\tACCESS GRANTED!");
                        var am = new AdminMenu();
                        am.AdminMainMenu();
                    }
                    else
                    {
                        Console.Beep();
                        Console.WriteLine("\n\tACCESS DENIED!");
                    }
                }
                else if (opt == 2)
                {
                    var cm = new CustomerMenu();
                    cm.CustomerMainMenu();
                }
                else if (opt == 0)
                {
                    isExit = true;
                }
                else
                {
                    Console.Beep();

                    Console.WriteLine("\n\tINVALID INPUT");
                }
            }

        }

    }
}