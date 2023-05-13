using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompsKitMarket.Core.Entities.Enums
{
    public enum HsdForms
    {
        [Display(Name = "2.5")]
        Compact,
        [Display(Name = "3.5")]
        Full
    }
}
