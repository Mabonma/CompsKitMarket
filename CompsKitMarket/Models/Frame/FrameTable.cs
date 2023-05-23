using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Models.Part;
using System.ComponentModel.DataAnnotations;

namespace CompsKitMarket.Models.Frame
{
    public class FrameTable : PartTable
    {
        [Display(Name = "Форма-фактор материнской платы")]
        public string MotherFormName { get; set; }

        [Display(Name = "Форма корпуса")]
        public FrameForm Form { get; set; }

        [Display(Name = "Цвет корпуса")]
        public Color Color { get; set; }

        [Display(Name = "Игровой")]
        public bool Game { get; set; }

        [Display(Name = "Максимальная длина видоекарты")]
        public int VideoLenght { get; set; }

        [Display(Name = "Максимальная высота кулера")]
        public int CoolHeight { get; set; }

        [Display(Name = "Максимальная длина блока питания")]
        public int ChargeLength { get; set; }

        [Display(Name = "Количество вентиляторов")]
        public byte Fans { get; set; }

        [Display(Name = "Внутренних остеков 3.5")]
        public byte InsideHsdSize3 { get; set; }

        [Display(Name = "Внутренних остеков 2.5")]
        public byte InsideHsdSize2 { get; set; }
    }
}
