using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;

namespace CompsKitMarket.Models.Part
{
    public class PartModel : BasedModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Обязательнео поле")]
        [Display(Name = "Производитель")]
        public int ManufacturerId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Картинка")]
        public IFormFile Image { get; set; }
    }
}
