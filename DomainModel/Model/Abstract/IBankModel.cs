using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVP.DomainModel.Abstract
{
    public interface IBankModel
    {
        bool Withdraw(string accountId, decimal sum, ITransaction transaction);
        void Deposit(string accountId, decimal sum, ITransaction transaction);
        decimal GetBalance(string accountId);
        ITransaction CreateTransaction();
    }
}
