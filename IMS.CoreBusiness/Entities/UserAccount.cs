using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness.Entities
{
    public class UserAccount
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле имя обязательно для заполнения")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Поле пароля обязательно для заполнения")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Обязательно выберите роль")]
        public string? Role { get; set; }
    }
}
