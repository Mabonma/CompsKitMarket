using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompsKitMarket.Core.Entities.Enums
{
    public enum TypeCooling
    {
        [Display(Name = "Воздушное")]
        Air,
        [Display(Name = "Пассивное")]
        Passive,
        [Display(Name = "Жидкосное")]
        Water,
        [Display(Name = "Воздушное + жидкостное")]
        WatAir
    }
}
