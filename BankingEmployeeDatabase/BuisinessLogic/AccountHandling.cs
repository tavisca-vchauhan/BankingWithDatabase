using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingEmployeeDatabase
{
    class AccountHandling : DataAccess,Interface
    {
        SqlConnection con;
        private string result, AccType;
        int balance;
        


        public SqlConnection Connect()
        {
            string connetionString;
            connetionString = @"Data Source=TAVDESK032;Initial Catalog=Banking;Integrated Security= true";
            con = new SqlConnection(connetionString);
            con.Open();
            return con;
        }


        public string GetNumber()
        {
            int number = Size(con);
            return Convert.ToString( 55020600 + number);          
        }


        public void Deposit(EmpFields emp)
        {
            Console.Write("Enter your Account Id : ");
            emp.AccId = Convert.ToInt32(Console.ReadLine());
            result = Search(emp.AccId, con);
            string[] tokens = result.Split(',');
            balance = Convert.ToInt32(tokens[0]);
            if (balance < 0)
            {
                Console.WriteLine(" No record found with this Account Id. Please try again....");
            }
            else
            {
                Console.WriteLine("Enter the amount you want to deposit ");
                int depo = Convert.ToInt32(Console.ReadLine());
                balance = balance+depo;
                Update(balance, con, emp.AccId);
            }

        }



        public void GetDetails(EmpFields emp)
        {
            Console.Write("Enter your Id : ");
            emp.AccId=Convert.ToInt32(Console.ReadLine());
            Display(emp.AccId,con);
        }


        public void Insert(EmpFields emp)
        {
        }



        public void Interest(EmpFields emp)
        {
            Console.Write("Enter your Id : ");
            emp.AccId = Convert.ToInt32(Console.ReadLine());
            result = Search(emp.AccId, con);
            string[] tokens = result.Split(',');
            balance = Convert.ToInt32(tokens[0]);
            if (balance < 0)
            {
                Console.WriteLine(" No record found with this Account Id. Please try again....");
            }
            else
            {
                AccType = tokens[1];
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
            
        }



        public void OpenAcc(EmpFields emp)
        {
            Console.WriteLine("Enter Name  & Account Type (savings |current | DMAT) :");
            emp.name = Console.ReadLine();
            emp.AccType = Console.ReadLine();
            Console.WriteLine("Enter starting balance :");
            emp.balance = Convert.ToInt32(Console.ReadLine());
            emp.AccId = Convert.ToInt32(GetNumber());
            InsertInto(emp, con);         
        }



        public void Withdraw(EmpFields emp)
        {
            //int bal = emp.balance;
            Console.Write("Enter your Id : ");
            emp.AccId = Convert.ToInt32(Console.ReadLine());
            result = Search(emp.AccId,con);
            string[] tokens = result.Split(',');
            balance = Convert.ToInt32(tokens[0]);
            if (balance<0)
            {
                Console.WriteLine(" No record found with this Account Id. Please try again....");
            }
            else
            {
                Console.WriteLine("Your available balance is : {0}", balance);
                AccType = tokens[1];
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
            }
            Update(balance,con,emp.AccId);

        }
    }
}
