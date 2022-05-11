using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using SrezAPI.Classes;

namespace SrezAPI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        bool passShow = false;
        static HttpClient client = new HttpClient();
        public static Account account;
        public PageLogin()
        {
            InitializeComponent();
        }
        private void btnShowPass_Click(object sender, RoutedEventArgs e)
        {
            if (!passShow)
            {
                txbPass.Text = psbPass.Password;
                psbPass.Visibility = Visibility.Collapsed;
                txbPass.Visibility = Visibility.Visible;
                passShow = true;
            }
            else
            {
                psbPass.Password = txbPass.Text;
                psbPass.Visibility = Visibility.Visible;
                txbPass.Visibility = Visibility.Collapsed;
                passShow = false;
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageReg());
        }

        private void ForgotPass_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageRestPass());
        }
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient request = new HttpClient())
            {
                var context = new StringContent("", Encoding.UTF8, "applocation/json");
                HttpResponseMessage httpResponseMessage = await client.GetAsync($"http://localhost:53140/api/Accounts?Email={txbEmail.Text}&Password={psbPass.Password}");
                var json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                if (json != "")
                {
                    account = JsonConvert.DeserializeObject<Account>(json);
                    FrameApp.frmObj.Navigate(new PageAccount());
                }
                else
                    MessageBox.Show("Неверные данные!","Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
