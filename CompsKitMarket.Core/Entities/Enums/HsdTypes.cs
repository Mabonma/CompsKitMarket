using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompsKitMarket.Core.Entities.Enums
{
    public enum HsdTypes
    {
        [Display(Name = "HDD")]
        Hdd,
        [Display(Name = "SSD")]
        Ssd,
        [Display(Name = "Гибридный")]
        Multi
    }
}
