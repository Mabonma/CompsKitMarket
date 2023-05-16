using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompsKitMarket.Models.Manufacturer
{
    public class ManufacturerTable : BasedModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        public string Name { get; set; } = null!;

        [Display(Name = "Количества ассортимента")]
        public int PartCount { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
