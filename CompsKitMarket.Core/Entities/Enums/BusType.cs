using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompsKitMarket.Core.Entities.Enums
{
    public enum BusType
    {
        [Display(Name = "32 бит")]
        Bit32,
        [Display(Name = "64 бит")]
        Bit64,
        [Display(Name = "96 бит")]
        Bit96,
        [Display(Name = "128 бит")]
        Bit128,
        [Display(Name = "160 бит")]
        Bit160,
        [Display(Name = "192 бит")]
        Bit192,
        [Display(Name = "256 бит")]
        Bit256,
        [Display(Name = "320 бит")]
        Bit320,
        [Display(Name = "352 бит")]
        Bit352,
        [Display(Name = "384 бит")]
        Bit384,
        [Display(Name = "448 бит")]
        Bit448,
        [Display(Name = "512 бит")]
        Bit512,
        [Display(Name = "3072 бит")]
        Bit3072,
        [Display(Name = "4096 бит")]
        Bit4096,
        [Display(Name = "5120 бит")]
        Bit5120
    }
}
