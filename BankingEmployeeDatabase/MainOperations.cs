
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace BankingEmployeeDatabase
{
   
    class Bank :AccountHandling
    {
        public static  SqlConnection con;

        public static void Main()
        {

            EmpFields emp = new EmpFields();
            AccountHandling accounts = new AccountHandling();
            con =accounts.Connect();

            top:
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
                    Console.WriteLine("You Entered wrong input. Please Try again...");
                    goto top;
                }
            
            Console.WriteLine("Do You want to Continue : Y or N ");
            char ch = Convert.ToChar(Console.ReadLine());
            ch = Char.ToUpper(ch);
            if (ch == 'Y')
                goto top;

        }

      
    }

}

