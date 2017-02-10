using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVP.Entities
{
    public class AccountChangedEventArgs : EventArgs
    {
        public AccountChangedEventArgs(string accountId)
        {
            this.AccountId = accountId;
        }

        public string AccountId { get; private set; }

    }
}
