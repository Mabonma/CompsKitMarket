using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompsKitMarket.Core.Entities.Enums
{
    public enum FrameForm
    {
        [Display(Name = "Super Tower")]
        Super,
        [Display(Name = "Full Tower")]
        Full,
        [Display(Name = "Mid Tower")]
        Mid,
        [Display(Name = "Mini Tower")]
        Mini,
        [Display(Name = "Серверный")]
        Server,
        [Display(Name = "Горизонтальный")]
        Horizont,
        [Display(Name = "Вертикальный настольный")]
        Vertical,
        [Display(Name = "Открытый корпус")]
        Open
    }
}
