using System.ComponentModel.DataAnnotations;

namespace CompsKitMarket.Models.Store
{
    public class StoreTable : BasedModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Время работы")]
        public string WorkMode { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "E-mail")]
        public string Mail { get; set; }

        [Display(Name = "Количество товара")]
        public int PartsCount { get; set; }
    }
}
