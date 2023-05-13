using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompsKitMarket.Core.Entities.Enums
{
    public enum GProcs
    {
        [Display(Name = "Amd")]
        AMD,
        [Display(Name = "Intel")]
        Intel,
        [Display(Name = "Nvidia")]
        Nvidia
    }
}
