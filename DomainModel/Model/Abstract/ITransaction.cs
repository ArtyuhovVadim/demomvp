using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVP.DomainModel.Abstract
{
    public interface ITransaction
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
