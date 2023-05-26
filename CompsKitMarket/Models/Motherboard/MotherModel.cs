using CompsKitMarket.Models.Part;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CompsKitMarket.Models.Motherboard
{
    public class MotherModel : PartModel
    {
        [NotMapped]
        public bool IsNew => Id == 0;

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Форм-фактор")]
        public int FormFactorId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Тип ОП")]
        public int TypeRamId { get; set; }

        [Display(Name = "Количество слотов ОП")]
        public int CountRam { get; set; }

        [Display(Name = "Максимальная частота памяти")]
        public int RamFreq { get; set; }

        [Display(Name = "M.2")]
        public byte M2 { get; set; }

        [Display(Name = "Sata 3")]
        public int Sata3 { get; set; }

        [Display(Name = "PCI Express x16")]
        public byte Pci16 { get; set; }

        [Display(Name = "PCI Express x8")]
        public byte Pci8 { get; set; }

        [Display(Name = "PCI Express x4")]
        public byte Pci4 { get; set; }

        [Display(Name = "PCI Express x1")]
        public byte Pci1 { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Сокет")]
        public int ProcSocketId { get; set; }
    }
}
