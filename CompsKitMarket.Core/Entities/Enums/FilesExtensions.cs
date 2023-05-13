using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompsKitMarket.Core.Entities.Enums
{
    public enum FilesExtensions
    {
        [Display(Name = ".jpg")]
        Jpg,
        [Display(Name = ".png")]
        Png,
        [Display(Name = ".gif")]
        Gif,
        [Display(Name = ".jpeg")]
        Jpeg
    }
}
