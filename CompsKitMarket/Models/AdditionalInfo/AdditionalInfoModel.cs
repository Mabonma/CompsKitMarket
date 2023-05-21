using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompsKitMarket.Models.AdditionalInfo
{
    public class AdditionalInfoModel
    {
        [NotMapped]
        public AdditionalInfoElement Element { get; set; }

        [NotMapped]
        public string AddToHtml { get; set; }
    }
}
