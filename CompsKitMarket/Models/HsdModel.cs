using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Core.Entities.Orders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CompsKitMarket.Models
{
    public class HsdModel : BasedModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Производитель")]
        public string ManufacturerName { get; set; } = null!;

        public int ManufacturerId { get; set; }

        [NotMapped]
        public bool IsNew => Id == 0;

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Тип жёсткого диска")]
        public HsdTypes Type { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Интерфейс")]
        public HsdConnections Connections { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Объём")]
        public int Vol { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Форм-фактор")]
        public HsdForms Form { get; set; }

        public bool Deleted { get; set; }
    }
}
