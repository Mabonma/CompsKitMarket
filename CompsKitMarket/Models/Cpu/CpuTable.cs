using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Core.Migrations;
using CompsKitMarket.Models.Part;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CompsKitMarket.Models.Cpu
{
    public class CpuTable : PartTable
    {
        [Display(Name = "Сокет")]
        public string ProcSocketName { get; set; }

        [Display(Name = "Модельный ряд")]
        public string ProcModelName { get; set; }

        [Display(Name = "Количество ядер")]
        public byte Cores { get; set; }

        [Display(Name = "Встроенная графика")]
        public bool Graf { get; set; }

        [Display(Name = "Кодовое название кристалла")]
        public string Crystal { get; set; }

        [Display(Name = "Базовая тактовая частота, ГГц")]
        public double BaseFreq { get; set; }

        [Display(Name = "Максимальная частота, ГГц")]
        public double MaxFreq { get; set; }

        [Display(Name = "Многопоточность ядра")]
        public bool MultiThread { get; set; }

        [Display(Name = "Расчетная тепловая мощность (TDP), Вт")]
        public int Tdp { get; set; }

        [Display(Name = "Тип поставки")]
        public BoxesType BoxType { get; set; }

        [Display(Name = "Техпроцесс, нм")]
        public int Tehprocess { get; set; }

        [Display(Name = "Поддержка памяти")]
        public string TypeRamName { get; set; }
    }
}
