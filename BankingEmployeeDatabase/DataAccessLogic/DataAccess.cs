using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BankingEmployeeDatabase
{
    class DataAccess
    {
        SqlCommand cmd;
        SqlDataReader dr;

        public void InsertInto(EmpFields emp ,SqlConnection con )
        {
           // employee employe = new employee();
            
            try
            {
                string s = "insert into employee(id , name , balance , accountType) values(@p1,@p2,@p3,@p4)";
                cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@p1", emp.AccId);
                cmd.Parameters.AddWithValue("@p2", emp.name);
                cmd.Parameters.AddWithValue("@p3",emp.balance);
                cmd.Parameters.AddWithValue("@p4", emp.AccType);
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("Your {0} Account is created with AccountID : {1}",emp.AccType,(55020600+count));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }



        int count = 0;
        public int Size(SqlConnection con)
        {         
            string s = "select id from employee ";
            cmd = new SqlCommand(s, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                   // Console.WriteLine(" data : {0} ",dr[0]);
                    count++;
                }
             }
            dr.Close();
            return ++count;
        }


        public void Update(int balance,SqlConnection con, int Id )
        {
            string s="UPDATE employee SET balance = @bal Where id = @AccId";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@bal", balance);
            cmd.Parameters.AddWithValue("@AccId", Id);
            cmd.ExecuteNonQuery();

        }

        public string Search(int id, SqlConnection con)
        {
            string s = "select * from employee where id =@p1 ";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@p1", id);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    id = Convert.ToInt32(dr[2]);
                    s = "";
                    s = Convert.ToString(dr[3]);
                    s = id + "," + s;
                    dr.Close();
                    return s;
                }
            }
            else
            {
                s = "";
                s += -1;
                dr.Close();
                return s;
            }
            return s;                  
        }



        public void Display(int id , SqlConnection con)
        {
            string s = "select * from employee where id = @p1";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@p1", id);
            dr = cmd.ExecuteReader();
            Console.WriteLine("-----------------------------------");

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Console.WriteLine("|    Account Id: {0} \n|    Name : {1} \n|    Balance : {2} \n|    Account Type : {3} ", dr[0], dr[1], dr[2], dr[3]);
                }
            }
            Console.WriteLine("-----------------------------------");
            dr.Close();

        }
    }
}
