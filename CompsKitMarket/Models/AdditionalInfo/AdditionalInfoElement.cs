using CompsKitMarket.Core.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CompsKitMarket.Models.AdditionalInfo
{
    public class AdditionalInfoElement : BasedModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Количество деталей")]
        public int PartCount { get; set; }

        [NotMapped]
        public bool IsNew => Id == 0;

        [NotMapped]
        public bool IsGprocs { get; set; } = false;

        [NotMapped]
        public bool IsCooler { get; set; } = false;

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Частота")]
        public double Freq { get; set; }

        [Display(Name = "Производитель процессора")]
        public GProcs GProcs { get; set; }
    }
}
