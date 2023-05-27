using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Models.Part;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace CompsKitMarket.Models.Video
{
    public class VideoModel : PartModel
    {
        [NotMapped]
        public bool IsNew => Id == 0;

        [Display(Name = "Графический процессор")]
        public int GrafProcId { get; set; }

        [Display(Name = "Видеопамять")]
        public int VramVol { get; set; }

        [Display(Name = "Тип видеопамяти")]
        public int VramTypeId { get; set; }

        [Display(Name = "Шина видеопамяти")]
        public BusType BusInter { get; set; }

        [Display(Name = "Охлаждение")]
        public TypeCooling Cooling { get; set; }

        [Display(Name = "Rtx")]
        public bool Rtx { get; set; }
    }
}
