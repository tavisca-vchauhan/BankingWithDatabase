using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingEmployeeDatabase
{
    interface Interface
    {
        SqlConnection Connect();
        void Insert(EmpFields r);

        void Interest(EmpFields r);

        void Deposit(EmpFields r);

        void Withdraw(EmpFields r);

        void GetDetails(EmpFields r);

        void OpenAcc(EmpFields r);


    }
}
