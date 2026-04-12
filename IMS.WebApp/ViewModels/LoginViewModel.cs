using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста пердоставте имя пользователя!")]
        public string? UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста предоставте пароль!")]
        public string? Password { get; set; }
    }
}
