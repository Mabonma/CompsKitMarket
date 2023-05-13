using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompsKitMarket.Core.Entities.Enums
{
    public enum Color
    {
        [Display(Name = "Чёрный")]
        Black,
        [Display(Name = "Красный")]
        Red,
        [Display(Name = "Серебристый")]
        Silver,
        [Display(Name = "Серый")]
        Grey,
        [Display(Name = "Белый")]
        White,
        [Display(Name = "Синий")]
        Blue,
        [Display(Name = "Голубой")]
        WhiteBlue,
        [Display(Name = "Титан")]
        Titan,
        [Display(Name = "Жёлтый")]
        Yellow,
        [Display(Name = "Прозрачный")]
        Clear,
        [Display(Name = "Оранжевый")]
        Orange,
        [Display(Name = "Зелёный")]
        Green,
        [Display(Name = "Розовый")]
        Pink,
        [Display(Name = "Золотой")]
        Gold,
        [Display(Name = "Бирюзовый")]
        BlueGreen
    }
}
