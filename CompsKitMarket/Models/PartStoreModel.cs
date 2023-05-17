using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompsKitMarket.Models
{
    public class PartStoreModel : BasedModel
    {
        [NotMapped]
        public bool IsNew => Id == 0;

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Id Магазина")]
        public int StoreId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Производитель")]
        public string ManufacturerName { get; set; }

        [Display(Name = "Цена")]
        public double Cost { get; set; }
    }
}
