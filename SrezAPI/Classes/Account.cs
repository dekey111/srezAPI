using System.Text.Json.Serialization;

namespace SrezAPI.Classes
{
     public class Account
    {
        [JsonPropertyName("UserID")]
        public int ID_User { get; set; }
        [JsonPropertyName("Login")]
        public string Login { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        [JsonPropertyName("Image")]
        public string Image { get; set; }
        [JsonPropertyName("SecondName")]
        public string SecondName { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Patronymic")]
        public string Patronymic { get; set; }
        [JsonPropertyName("Emaill")]
        public string Emaill { get; set; }
    }
}
