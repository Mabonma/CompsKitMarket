using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Models.Part;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CompsKitMarket.Models.Cooler
{
    public class CoolerTable : PartTable
    {
        [Display(Name = "Тип")]
        public string CoolerTypeName { get; set; }

        [Display(Name = "Сокет")]
        [AllowNull]
        public string ProcSocketName { get; set; }

        [Display(Name = "Охлаждение")]
        public TypeCooling TypeCooling { get; set; }

        [Display(Name = "Диаметр вентилятора, мм")]
        public int Diam { get; set; }

        [Display(Name = "Рассеиваемая мощность, Вт")]
        public int Tdp { get; set; }

        [Display(Name = "Количество вентиляторов")]
        public byte CountFan { get; set; }

        [Display(Name = "Высота (толщина), мм")]
        public double Height { get; set; }

        [Display(Name = "Ширина, мм")]
        public double Width { get; set; }

        [Display(Name = "Максимальная скорость вращения, об/мин")]
        public int Rpm { get; set; }

    }
}
