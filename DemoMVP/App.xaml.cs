using DemoMVP.Abstract;
using DemoMVP.DomainModel;
using DemoMVP.DomainModel.Abstract;
using DemoMVP.Presenter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoMVP
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            IBankModel model = new SimpleBankModel(new List<Account>() 
            {
                new Account() { Id = "1", Balance = 5000 },
                new Account() { Id = "2", Balance = 2000 },
                new Account() { Id = "3", Balance = 500 },
                new Account() { Id = "4", Balance = 5500 }
            });
            MainWindow view = new MainWindow();

            TransferPresenter presenter = new TransferPresenter(model, view);

            App app = new App();
            app.Run(view);
        }
    }
}
