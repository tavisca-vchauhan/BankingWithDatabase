
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace BankingEmployeeDatabase
{
   
    class Bank 
    {
        public static  SqlConnection con;

        public static void Main()
        {
            bool cont = true;
            while (cont)
            {
                Console.WriteLine("Which Framework You want to use:\n1 for ADO.Net \n2 for Entity Framework");
                int framework = Convert.ToInt32(Console.ReadLine());
                if (framework == 1)
                {
                    EmpFields emp = new EmpFields();
                    AccountHandling accounts = new AccountHandling();
                    con = accounts.Connect();
                    top:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Enter \n 1 To Open new account \n 2 To Display account details \n 3 To Withdraw some amount \n 4 To Deposit money \n 5 To check Interest ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        accounts.OpenAcc(emp);
                    }
                    else if (choice == 2)
                    {

                        accounts.GetDetails(emp);
                    }
                    else if (choice == 3)
                    {
                        accounts.Withdraw(emp);

                    }
                    else if (choice == 4)
                    {
                        accounts.Deposit(emp);

                    }
                    else if (choice == 5)
                    {
                        accounts.Interest(emp);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You Entered wrong input. Please Try again...");
                        goto top;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Do You want to Continue : Y or N ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    ch = Char.ToUpper(ch);
                    if (ch == 'Y')
                        goto top;

                }
                else if(framework == 2)
                {
                    employee emp = new employee();
                    AccountHandlingByEntity accounts = new AccountHandlingByEntity();                  
                    top:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Enter \n 1 To Open new account \n 2 To Display account details \n 3 To Withdraw some amount \n 4 To Deposit money \n 5 To check Interest ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        accounts.OpenAcc(emp);
                    }
                    else if (choice == 2)
                    {

                        accounts.GetDetails(emp);
                    }
                    else if (choice == 3)
                    {
                        accounts.Withdraw(emp);

                    }
                    else if (choice == 4)
                    {
                        accounts.Deposit(emp);

                    }
                    else if (choice == 5)
                    {
                        accounts.Interest(emp);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You Entered wrong input. Please Try again...");
                        goto top;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Do You want to Continue : Y or N ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    ch = Char.ToUpper(ch);
                    if (ch == 'Y')
                        goto top;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Wrong Input. Please try again....");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Do You want to Switch Framework : Y or N ");
                char ch1 = Convert.ToChar(Console.ReadLine());
                ch1 = Char.ToUpper(ch1);
                if (ch1 != 'Y')
                {
                    cont = false;
                }
                

            }
        }

      
    }

}

