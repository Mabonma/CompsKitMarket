using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Models.Part;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace CompsKitMarket.Models.Cpu
{
    public class CpuModel : PartModel
    {
        [NotMapped]
        public bool IsNew => Id == 0;

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Сокет")]
        public int ProcSocketId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Модельный ряд")]
        public int ProcModelId { get; set; }

        [Display(Name = "Количество ядер")]
        public byte Cores { get; set; }

        [Display(Name = "Встроенная графика")]
        public bool Graf { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Кодовое название кристалла")]
        public string Crystal { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Базовая тактовая частота, ГГц")]
        public double BaseFreq { get; set; }

        [Display(Name = "Максимальная частота, ГГц")]
        public double MaxFreq { get; set; }

        [Display(Name = "Многопоточность ядра")]
        public bool MultiThread { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Расчетная тепловая мощность (TDP), Вт")]
        public int Tdp { get; set; }

        [Display(Name = "Тип поставки")]
        public BoxesType BoxType { get; set; }

        [Display(Name = "Техпроцесс, нм")]
        public int Tehprocess { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Поддержка памяти")]
        public int TypeRamId { get; set; }
    }
}
