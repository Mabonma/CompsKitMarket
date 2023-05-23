using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using CompsKitMarket.Models.Part;

namespace CompsKitMarket.Models.Charge
{
    public class ChargeModel : PartModel
    {
        [NotMapped]
        public bool IsNew => Id == 0;

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Количество CPU 4 pin")]
        public byte Cpu4 { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Количество CPU 8 pin")]
        public byte Cpu8 { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Количество SATA")]
        public byte Sata { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Количество PCIe 6 pin")]
        public byte Pcle6 { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Количество PCIe 8 pin")]
        public byte Pcle8 { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Количество PCIe Gen5 (16 pin)")]
        public byte Pcle16 { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Количество FDD 4 pin")]
        public byte Fdd { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Количество IDE 4 pin")]
        public byte Ide { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Количество USB Power")]
        public byte Usb { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Высота, мм")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Ширина, мм")]
        public double Width { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Глубина, мм")]
        public double Deep { get; set; }
    }
}
