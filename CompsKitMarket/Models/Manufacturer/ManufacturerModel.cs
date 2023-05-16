using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections.Generic;
using CompsKitMarket.Core.Entities.Kits;

namespace CompsKitMarket.Models.Manufacturer
{
    public class ManufacturerModel : BasedModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        public string Name { get; set; } = null!;

        [NotMapped]
        public bool IsNew => Id == 0;

        [Display(Name = "Количества ассортимента")]
        public int PartCount { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
