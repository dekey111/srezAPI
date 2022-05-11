using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using SrezAPI.Classes;

namespace SrezAPI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        bool passShowF = false;
        bool passShowS = false;
        public PageReg()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageLogin());
        }

        private void btnShowFPass_Click(object sender, RoutedEventArgs e)
        {
            if (!passShowF)
            {
                txbPassF.Text = psbPassF.Password;
                psbPassF.Visibility = Visibility.Collapsed;
                txbPassF.Visibility = Visibility.Visible;
                passShowF = true;
            }
            else
            {
                psbPassF.Password = txbPassF.Text;
                psbPassF.Visibility = Visibility.Visible;
                txbPassF.Visibility = Visibility.Collapsed;
                passShowF = false;
            }
        }

        private void btnShowPassS_Click(object sender, RoutedEventArgs e)
        {
            if (!passShowS)
            {
                txbPassS.Text = psbPassS.Password;
                psbPassS.Visibility = Visibility.Collapsed;
                txbPassS.Visibility = Visibility.Visible;
                passShowS = true;
            }
            else
            {
                psbPassS.Password = txbPassS.Text;
                psbPassS.Visibility = Visibility.Visible;
                txbPassS.Visibility = Visibility.Collapsed;
                passShowS = false;
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (txbSurname.Text.Length < 1 && txbName.Text.Length < 1 && txbPatron.Text.Length < 1 && txbEmail.Text.Length < 1 && txbPassF.Text.Length < 1 && txbPassS.Text.Length < 1)
                MessageBox.Show("Заполните данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbPassF.Text != txbPassS.Text)
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                Account account = new Account()
                {
                    Login = txbEmail.Text,
                    Password = psbPassS.Password,
                    Emaill = txbEmail.Text,
                    Name = txbName.Text,
                    SecondName = txbSurname.Text,
                    Patronymic = txbPatron.Text
                };
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://localhost:53140/api/Accounts");
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "POST";
                var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(account));
                if (account != null)
                {
                    httpWebRequest.ContentLength = bytes.Length;
                    using (var requestStream = httpWebRequest.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                    }
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Debug.WriteLine(JsonConvert.SerializeObject(account));

                MessageBox.Show("Аккаунт успешно создан!", "Создание аккаунта", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}
