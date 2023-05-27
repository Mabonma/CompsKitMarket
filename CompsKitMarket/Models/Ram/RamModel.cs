using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Models.Part;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace CompsKitMarket.Models.Ram
{
    public class RamModel : PartModel
    {
        [NotMapped]
        public bool IsNew => Id == 0;

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Тип")]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Общий объем")]
        public double Vol { get; set; }

        [Display(Name = "Набор")]
        public byte Count { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Частота")]
        public int Freq { get; set; }

        [Display(Name = "Тайминги")]
        public string Timings { get; set; }
    }
}
