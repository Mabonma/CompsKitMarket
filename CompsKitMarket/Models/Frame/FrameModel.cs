using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Models.Part;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CompsKitMarket.Models.Frame
{
    public class FrameModel : PartModel
    {
        [NotMapped]
        public bool IsNew => Id == 0;

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Форма-фактор материнской платы")]
        public int MotherFormId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Форма корпуса")]
        public FrameForm Form { get; set; }

        [Display(Name = "Цвет корпуса")]
        public Color Color { get; set; }

        [Display(Name = "Игровой")]
        public bool Game { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Максимальная длина видоекарты")]
        public int VideoLenght { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Максимальная высота кулера")]
        public int CoolHeight { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Максимальная длина блока питания")]
        public int ChargeLength { get; set; }

        [Display(Name = "Количество вентиляторов")]
        public byte Fans { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Внутренних остеков 3.5")]
        public byte InsideHsdSize3 { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Внутренних остеков 2.5")]
        public byte InsideHsdSize2 { get; set; }
    }
}
