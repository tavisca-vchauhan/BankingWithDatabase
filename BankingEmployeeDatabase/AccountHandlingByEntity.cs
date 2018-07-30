using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingEmployeeDatabase
{
    class AccountHandlingByEntity : DataAccess, Interface1
    {
        SqlConnection con;
        private string result, AccType;
        int balance;

        BankingEntities bankingEntities = new BankingEntities();


        public string GetNumber()
        {
            int number = Size(con);
            return Convert.ToString(55020600 + number);
        }


        public void Deposit(employee emp)
        {
            try
            {
                Console.Write("Enter your Account Id : ");
                emp.id = Convert.ToInt32(Console.ReadLine());
                balance = Convert.ToInt32(bankingEntities.employees.Find(emp.id).balance);
                Console.WriteLine("Enter the amount you want to deposit ");
                int depo = Convert.ToInt32(Console.ReadLine());
                balance = balance + depo;
                bankingEntities.employees.Find(emp.id).balance = balance;
                bankingEntities.SaveChanges();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" No record found with this Account Id. Please try again....");
            }


        }





        public void Insert(employee emp)
        {
        }



        public void GetDetails(employee emp)
        {
                Console.Write("Enter your Id : ");
                emp.id = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Cyan;
                List<employee> emplyee = new List<employee>();
                emplyee = bankingEntities.employees.ToList();
                foreach (employee data in emplyee)
                {
                    if(emp.id==Convert.ToInt32( data.id))
                    Console.WriteLine("|    Account Id: {0} \n|    Name : {1} \n|    Balance : {2} \n|    Account Type : {3} ", data.id, data.name, data.balance, data.accountType);
                }
                Console.ResetColor();
            }




            public void Interest(employee emp)
        {
            try
            {
                Console.Write("Enter your Id : ");
                emp.id = Convert.ToInt32(Console.ReadLine());
                balance = Convert.ToInt32(bankingEntities.employees.Find(emp.id).balance);
                result = Convert.ToString(bankingEntities.employees.Find(emp.id).accountType);
                Console.WriteLine("Your available balance is : {0}", balance);
                AccType = result;
                char[] ch = AccType.ToCharArray();
                AccType = ch[0] + "";
                float simpleInterest = 0;
                if (AccType == "s")
                {
                    simpleInterest = (balance * 4 * 1) / 100;
                    Console.WriteLine("Interest is: {0} Rs per Year", simpleInterest);
                }
                else if (AccType == "c")
                {
                    simpleInterest = (balance * 1 * 1) / 100;
                    Console.WriteLine("Interest is: {0} Rs per Year", simpleInterest);
                }
                else
                {
                    Console.WriteLine("Interest cannot be appliet on DMAT's Account");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(" No record found with this Account Id. Please try again....");
            }

        }  



        public void OpenAcc(employee emp)
        {
            Console.WriteLine("Enter Name  & Account Type (savings |current | DMAT) :");
            emp.name = Console.ReadLine();
            emp.accountType = Console.ReadLine();
            Console.WriteLine("Enter starting balance :");
            emp.balance = Convert.ToInt32(Console.ReadLine());
            emp.id = Convert.ToInt32(GetNumber());
            var value = new employee
            {
                id = emp.id,
                name = emp.name,
                balance = emp.balance,
                accountType=emp.accountType
            };
            bankingEntities.employees.Add(value);
            bankingEntities.SaveChanges();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Your new {0} account is created with Account No : {1}",emp.accountType,emp.id);

        }



        public void Withdraw(employee emp)
        {
            //int bal = emp.balance;
            Console.Write("Enter your Id : ");
            emp.id = Convert.ToInt32(Console.ReadLine());
            try
            {
                balance = Convert.ToInt32(bankingEntities.employees.Find(emp.id).balance);
                result = Convert.ToString(bankingEntities.employees.Find(emp.id).accountType);                       
                Console.WriteLine("Your available balance is : {0}", balance);
                AccType = result;
                char[] ch = AccType.ToCharArray();
                AccType = ch[0] + "";
                Console.WriteLine("Enter the amount you want to withdraw ");
                int draw = Convert.ToInt32(Console.ReadLine());
                if (AccType == "s")
                {
                    if ((balance - draw) < 1000)
                    {
                        Console.WriteLine("Minimum Balance in savings account must be 1000 Rs. Please withdraw some less amount.");
                    }
                    else
                    {
                        balance = balance - draw;
                    }
                }
                else if (AccType == "c")
                {
                    if ((balance - draw) < 0)
                    {
                        Console.WriteLine("Minimum Balance in current account must be 0 Rs. Please withdraw some less amount.");
                    }
                    else
                    {
                        balance = balance - draw;
                    }
                }
                else
                {
                    if ((balance - draw) < -10000)
                    {
                        Console.WriteLine("Minimum Balance in current account must be -10000 Rs. Please withdraw some less amount.");
                    }
                    else
                    {
                        balance = balance - draw;
                    }
                }
                bankingEntities.employees.Find(emp.id).balance = balance;
                bankingEntities.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(" No record found with this Account Id. Please try again....");
            }
           
        }
    }
}
