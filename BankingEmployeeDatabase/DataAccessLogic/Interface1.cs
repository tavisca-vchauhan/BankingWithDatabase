using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingEmployeeDatabase
{
    interface Interface1
    {
                
            void Insert(employee r);

            void Interest(employee r);

            void Deposit(employee r);

            void Withdraw(employee r);

            void GetDetails(employee r);

            void OpenAcc(employee r);


        
    }

}
