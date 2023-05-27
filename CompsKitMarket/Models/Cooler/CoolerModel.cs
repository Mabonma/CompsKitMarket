using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Models.Part;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace CompsKitMarket.Models.Cooler
{
    public class CoolerModel : PartModel
    {
        [NotMapped]
        public bool IsNew => Id == 0;

        [Display(Name = "Сокет")]
        [AllowNull]
        public int? ProcSocketId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Тип")]
        public int CoolerTyperId { get; set; }

        [Display(Name = "Охлаждение")]
        public TypeCooling TypeCooling { get; set; }

        [Display(Name = "Диаметр вентилятора, мм")]
        public int Diam { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Рассеиваемая мощность, Вт")]
        public int Tdp { get; set; }

        [Display(Name = "Количество вентиляторов")]
        public byte CountFan { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Высота (толщина), мм")]
        public double Height { get; set; }

        [Display(Name = "Ширина, мм")]
        public double Width { get; set; }

        [Display(Name = "Максимальная скорость вращения, об/мин")]
        public int Rpm { get; set; }
    }
}
