using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropExp
{
    internal class ReadExmp
    {
        class Bank
        {
            public int AccountNo { get; } = 5687564;
            public string BranchName { get; } = "KTPS";
            public string BankName { get; } = "Union Bank";
        }
        internal class ReadOnlyExample
        {
            static void Main()
            {
                Bank bank = new Bank();
                Console.WriteLine("Account No  " + bank.AccountNo);
                Console.WriteLine("Bank Name  " + bank.BankName);
                Console.WriteLine("Branch Name  " + bank.BranchName);
            }
        }
    }
}
