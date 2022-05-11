using LoginAPi.Entities;
namespace LoginAPi.Models
{
    public class ResponseAccounts
    {
        public int ID_User { get; set; }
        public string Image { get; set; }
        public string SecondName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public ResponseAccounts(Account account)
        {
            ID_User = account.UserID;
            Image = account.Image;
            SecondName = account.SecondName;
            Name = account.Name;
            Patronymic = account.Patronymic;
        }

    }
}