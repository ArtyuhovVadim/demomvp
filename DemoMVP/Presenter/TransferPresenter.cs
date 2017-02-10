using DemoMVP.Abstract;
using DemoMVP.DomainModel.Abstract;
using DemoMVP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVP.Presenter
{
    public class TransferPresenter
    {
        private IBankModel model;
        private ITransferView view;

        public TransferPresenter(IBankModel model, ITransferView view)
        {
            this.model = model;
            this.view = view;

            this.view.SrcAccountChanged += view_SrcAccountChanged;
            this.view.DestAccountChanged += view_DestAccountChanged;
            this.view.TransferMoney += view_TransferMoney;
        }

        private void view_SrcAccountChanged(object sender, AccountChangedEventArgs e)
        {
            try
            {
                decimal balance = model.GetBalance(e.AccountId);
                view.UpdateSrcBalance(balance);
            }
            catch(ApplicationException ex)
            {
                view.ShowError(ex.Message);
            }
        }

        private void view_DestAccountChanged(object sender, AccountChangedEventArgs e)
        {
            try
            {
                decimal balance = model.GetBalance(e.AccountId);
                view.UpdateDestBalance(balance);
            }
            catch (ApplicationException ex)
            {
                view.ShowError(ex.Message);
            }
        }

        private void view_TransferMoney(object sender, TransferMoneyEventArgs e)
        {
            ITransaction tran = model.CreateTransaction();
            try
            {
                tran.Begin();
                bool success = model.Withdraw(e.SrcAccountId, e.Sum, tran);
                if (success)
                {
                    model.Deposit(e.DestAccountId, e.Sum, tran);
                    tran.Commit();
                    view.UpdateSrcBalance(model.GetBalance(e.SrcAccountId));
                    view.UpdateDestBalance(model.GetBalance(e.DestAccountId));
                }
                else
                {
                    tran.Rollback();
                    view.ShowWarning("Недостаточно денег для перевода");
                }
            }
            catch(ApplicationException ex)
            {
                tran.Rollback();
                view.ShowError(ex.Message);
            }
        }
    }
}
