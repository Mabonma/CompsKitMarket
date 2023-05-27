using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Core.Migrations;
using CompsKitMarket.Models.Part;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CompsKitMarket.Models.Video
{
    public class VideoTable : PartTable
    {
        [Display(Name = "Графический процессор")]
        public string GrafProcName { get; set; }

        [Display(Name = "Производитель графического ядра")]
        public GProcs GrafProcManuf { get; set; }

        [Display(Name = "Видеопамять")]
        public int VramVol { get; set; }

        [Display(Name = "Тип видеопамяти")]
        public string VramTypeName { get; set; }

        [Display(Name = "Шина видеопамяти")]
        public BusType BusInter { get; set; }

        [Display(Name = "Охлаждение")]
        public TypeCooling Cooling { get; set; }

        [Display(Name = "Rtx")]
        public bool Rtx { get; set; }
    }
}
