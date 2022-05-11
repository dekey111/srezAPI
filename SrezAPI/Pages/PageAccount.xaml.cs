using SrezAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SrezAPI.Classes;
namespace SrezAPI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAccount.xaml
    /// </summary>
    public partial class PageAccount : Page
    {
        Account ac = PageLogin.account;
        public PageAccount()
        {
            InitializeComponent();
            txbName.Text = ac.Name;
            txbSurname.Text = ac.SecondName;
            txbMiddle.Text = ac.Patronymic;
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageLogin());
        }
    }
}
