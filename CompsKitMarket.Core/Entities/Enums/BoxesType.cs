using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompsKitMarket.Core.Entities.Enums
{
    public enum BoxesType
    {
        [Display(Name = "OEM")]
        Oem,
        [Display(Name = "BOX")]
        Box,
        [Display(Name = "BOX Limited Edition")]
        BoxLimited,
        [Display(Name = "Multipack")]
        Multipack
    }
}
