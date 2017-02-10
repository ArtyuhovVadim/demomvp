using DemoMVP.Abstract;
using DemoMVP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoMVP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ITransferView
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string srcAccountId = string.Empty;
        private string destAccountId = string.Empty;

        public void UpdateSrcBalance(decimal balance)
        {
            lblSrcBalance.Content = balance.ToString();
        }

        public void UpdateDestBalance(decimal balance)
        {
            lblDestBalance.Content = balance.ToString();
        }

        public void ShowWarning(string text)
        {
            MessageBox.Show(text, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ShowError(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public event EventHandler<TransferMoneyEventArgs> TransferMoney;

        protected virtual void OnTransferMoney(TransferMoneyEventArgs e)
        {
            if (TransferMoney != null)
            {
                TransferMoney(this, e);
            }
        }

        public event EventHandler<AccountChangedEventArgs> SrcAccountChanged;

        protected virtual void OnSrcAccountChanged(AccountChangedEventArgs e)
        {
            if (SrcAccountChanged != null)
            {
                SrcAccountChanged(this, e);
            }
        }

        public event EventHandler<AccountChangedEventArgs>DestAccountChanged;

        protected virtual void OnDestAccountChanged(AccountChangedEventArgs e)
        {
            if (DestAccountChanged != null)
            {
                DestAccountChanged(this, e);
            }
        }

        private void txtSrcAccount_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSrcAccount.Text) && txtSrcAccount.Text != srcAccountId)
            {
                OnSrcAccountChanged(new AccountChangedEventArgs(txtSrcAccount.Text));
                srcAccountId = txtSrcAccount.Text;
            }
        }

        private void txtDestAccount_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDestAccount.Text) && txtDestAccount.Text != destAccountId)
            {
                OnDestAccountChanged(new AccountChangedEventArgs(txtDestAccount.Text));
                destAccountId = txtDestAccount.Text;
            }
        }

        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            decimal sum;
            if (decimal.TryParse(txtSum.Text, out sum))
            {
                OnTransferMoney(new TransferMoneyEventArgs(txtSrcAccount.Text, txtDestAccount.Text, sum));
            }
            else
            {
                ShowWarning("Ошибка ввода суммы");
            }
        }
    }
}
