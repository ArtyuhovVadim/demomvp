using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVP.Entities
{
    public class TransferMoneyEventArgs : EventArgs
    {
        public TransferMoneyEventArgs(string src, string dest, decimal sum)
        {
            this.SrcAccountId = src;
            this.DestAccountId = dest;
            this.Sum = sum;
        }

        public string SrcAccountId { get; private set; }
        public string DestAccountId { get; private set; }
        public decimal Sum { get; private set; }
    }
}
