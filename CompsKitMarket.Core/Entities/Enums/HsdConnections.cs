using System.ComponentModel.DataAnnotations;

namespace CompsKitMarket.Core.Entities.Enums
{
    public enum HsdConnections
    {
        [Display(Name = "SATA 3.0 (6Gbps)")]
        Sata3,
        [Display(Name = "SATA 2.0 (3Gbps)")]
        Sata2,
        [Display(Name = "SAS 3.0 (12Gbps)")]
        Sas3,
        [Display(Name = "SAS 2.0 (6Gbps)")]
        Sas2,
        [Display(Name = "SAS 1.0 (3Gbps)")]
        Sas1,
        [Display(Name = "IDE")]
        Ide,
        [Display(Name = "Fibre Channel (4Gbps)")]
        Fibre,
        [Display(Name = "SCSI")]
        Scsi,
        [Display(Name = "SAS")]
        Sas,
        [Display(Name = "SATA")]
        Sata
    }
}
