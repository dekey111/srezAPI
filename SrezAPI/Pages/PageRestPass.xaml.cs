using Newtonsoft.Json;
using SrezAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace SrezAPI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageRestPass.xaml
    /// </summary>
    public partial class PageRestPass : Page
    {
        static HttpClient client = new HttpClient();
        public static Account account;
        public PageRestPass()
        {
            InitializeComponent();
        }

        private async void fostan_clickAsync(object sender, RoutedEventArgs e)
        {
            using (HttpClient request = new HttpClient())
            {
                var context = new StringContent("", Encoding.UTF8, "applocation/json");
                HttpResponseMessage httpResponseMessage = await client.GetAsync($"http://localhost:53140/api/Accounts?Email={txbEmail.Text}");
                var json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                if (json != "")
                {
                    account = JsonConvert.DeserializeObject<Account>(json);

                    if (txbEmail.Text != account.Emaill)
                        MessageBox.Show("Такой Email не зарегистрирован", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                        FrameApp.frmObj.Navigate(new PageChangePass());
                }
                else
                    MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageLogin());
        }
    }
}
