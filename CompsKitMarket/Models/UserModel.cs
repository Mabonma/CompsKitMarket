using System.ComponentModel.DataAnnotations;

namespace CompsKitMarket.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; } = null!;

        [Display(Name = "Имя")]
        public string? Name { get; set; }

        [Display(Name = "Отчество")]
        public string? SecondName { get; set; }


        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Телефон")]
        public string Mobile { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Адрес")]
        public string Address { get; set; } = null!;


        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Логин")]
        public string Login { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string? PasswordConfirm { get; set; }
    }
}
