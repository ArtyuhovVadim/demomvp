using DemoMVP.DomainModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVP.DomainModel
{
    public class Transaction : ITransaction
    {
        public void Begin() { }
        public void Commit() { }
        public void Rollback() { }

        internal void SaveState(Account account) { }
    }
}
