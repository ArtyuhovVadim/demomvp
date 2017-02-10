using DemoMVP.DomainModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVP.DomainModel
{
    /// <summary>
    /// Простая модель, инкапсулирующая банковские операции над существующими счетами
    /// </summary>
    public class SimpleBankModel : IBankModel
    {
        private IList<Account> accounts;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="accounts">Список всех счетов</param>
        public SimpleBankModel(IList<Account> accounts)
        {
            this.accounts = accounts;
        }

        /// <summary>
        /// Снять деньги со счета
        /// </summary>
        /// <param name="accountId">Идентификатор счета</param>
        /// <param name="sum">сумма</param>
        /// <param name="transaction">объект транзакции</param>
        /// <returns>True, если успешно. False - если нет такой суммы на балансе</returns>
        public bool Withdraw(string accountId, decimal sum, ITransaction transaction)
        {
            EnsureSum(sum);
            Account account = GetAccountById(accountId);
            if (account.Balance < sum)
            {
                return false;
            }

            (transaction as Transaction).SaveState(account);
            account.Balance -= sum;
            return true;
        }

        /// <summary>
        /// Внести деньги на счет
        /// </summary>
        /// <param name="accountId">Идентификатор счета</param>
        /// <param name="sum">сумма</param>
        /// <param name="transaction">объект транзакции</param>
        public void Deposit(string accountId, decimal sum, ITransaction transaction)
        {
            EnsureSum(sum);
            Account account = GetAccountById(accountId);
            (transaction as Transaction).SaveState(account);
            account.Balance += sum;
        }

        /// <summary>
        /// Получить баланс счета
        /// </summary>
        /// <param name="accountId">Идентификатор счета</param>
        /// <returns>Сумма денег на счету</returns>
        public decimal GetBalance(string accountId)
        {
            Account account = GetAccountById(accountId);
            return account.Balance;
        }

        /// <summary>
        /// Создать объект транзакции
        /// </summary>
        /// <returns>Объект транзакции</returns>
        public ITransaction CreateTransaction()
        {
            return new Transaction();
        }

        private void EnsureSum(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ApplicationException("Sum must be greater than 0");
            } 
        }

        private Account GetAccountById(string accountId)
        {
            Account account = accounts.Where(x => x.Id == accountId).FirstOrDefault();
            if (account == null)
            {
                throw new ApplicationException("Account not found");
            }
            return account;
        }
    }
}
