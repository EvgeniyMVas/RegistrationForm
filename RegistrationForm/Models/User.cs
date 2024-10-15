using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RegistrationForm.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Имя", Prompt = "Введите имя...")]
        [Required(ErrorMessage = "Имя обязательно для заполнения!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Укажите имя длинной от 2-ух до 20 символов")]
        public string FirstName {  get; set; }
        [Display(Name = "Фамилия", Prompt = "Введите имя...")]
        [Required(ErrorMessage = "Фамилия обязательна для заполнения!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Укажите фамилию длинной от 2-ух до 20 символов")]
        public string LastName { get; set; }
        [Display(Name = "Имя пользователя", Prompt = "Введите ник пользователя...")]
        [Required(ErrorMessage = "Имя пользователя обязательно для заполнения!")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Имя пользователя должно быть длинной от 5-ти до 20 символов")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Имя пользователя должно содержать только буквы, цифры и подчеркивания.")]
        [Remote(action: "IsUserNameAvailable", controller: "Account", ErrorMessage = "Имя пользователя уже занято.")]
        public string UserName { get; set; }
        [Display(Name = "Возраст", Prompt = "Введите возраст...")]
        [Required(ErrorMessage = "Возраст обязателен для заполнения!")]
        [Range(minimum: 18, maximum: 100, ErrorMessage = "Укажите возраст в промежутке от 18 до 100")]

        public int? Age { get; set; }
        [Display(Name = "Телефон", Prompt = "Введите номер телефона...")]
        [Phone(ErrorMessage = "Некорректный номер телефона")]
        //[RegularExpression(@"^8\s\(\d{3}\)\s\d{3}-\d{2}-\d{2}$", 
        //    ErrorMessage = "Неверный формат номера телефона. Ожидаемый формат: 8 (0XX) XXX-XX-XX.")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "E-Mail", Prompt = "Введите E-Mail...")]
        [Required(ErrorMessage = "Укажите E-Mail!")]
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "Пароль", Prompt = "Введите пароль...")]
        [Required(ErrorMessage = "Укажите пароль!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль должен быть длиной от 6 до 100 символов")]
        public string? Password { get; set; }

        [Display(Name = "Подтвердите пароль", Prompt = "Повторите пароль...")]
        [Required(ErrorMessage = "Повторите пароль!")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string? ConfirmPassword { get; set; }
        [Display(Name = "Условия обслуживания", Prompt = "Примите условия обслуживания...")]
        [ValidateNever]
        public bool TermsOfService {  get; set; }
        [Display(Name = "Веб-сайт", Prompt = "Введите адрес сайта...")]
        [Url(ErrorMessage = "Некорректный URL-адрес")]
        public string? Website { get; set; }

        [Display(Name = "Номер кредитной карты", Prompt = "Введите номер кредитной карты...")]
        [CreditCard(ErrorMessage = "Некорректный номер кредитной карты")]
        public string? CreditCardNumber { get; set; }

    }
}
