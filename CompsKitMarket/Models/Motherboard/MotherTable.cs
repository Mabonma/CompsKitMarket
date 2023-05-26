using CompsKitMarket.Models.Part;
using System.ComponentModel.DataAnnotations;

namespace CompsKitMarket.Models.Motherboard
{
    public class MotherTable : PartTable
    {
        [Display(Name = "Форм-фактор")]
        public string FormFactorName { get; set; }

        [Display(Name = "Тип ОП")]
        public string TypeRamName { get; set; }

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

        [Display(Name = "Сокет")]
        public string ProcSocketName { get; set; }

    }
}
