using DemoMVP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVP.Abstract
{
    public interface ITransferView
    {
        /// <summary>
        /// Обновить баланс счета-источника
        /// </summary>
        /// <param name="balance">Сумма на балансе</param>
        void UpdateSrcBalance(decimal balance);

        /// <summary>
        /// Обновить баланс счетаназначения
        /// </summary>
        /// <param name="balance">Сумма на балансе</param>
        void UpdateDestBalance(decimal balance);

        /// <summary>
        /// Отобразить предупреждение
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        void ShowWarning(string text);

        /// <summary>
        /// Отобразить ошибку
        /// </summary>
        /// <param name="text">Текст ошибки</param>
        void ShowError(string text);

        /// <summary>
        /// Событие, срабатывающее при изменении идентификатора счета-источника
        /// </summary>
        event EventHandler<AccountChangedEventArgs> SrcAccountChanged;

        /// <summary>
        /// Событие, срабатывающее при изменении идентификатора счета-назначения
        /// </summary>
        event EventHandler<AccountChangedEventArgs> DestAccountChanged;

        /// <summary>
        /// Событие, срабатывающее при запросе перевода денег
        /// </summary>
        event EventHandler<TransferMoneyEventArgs> TransferMoney;
    }
}
