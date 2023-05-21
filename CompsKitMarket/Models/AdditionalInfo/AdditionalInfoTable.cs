using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompsKitMarket.Models.AdditionalInfo
{
    public class AdditionalInfoTable
    {
        [NotMapped]
        public IEnumerable<AdditionalInfoElement> Elements { get; set; }

        [NotMapped]
        public string AddToHtml { get; set; }

        [NotMapped]
        public bool IsGproc { get; set; } = false;

        [NotMapped]
        public bool IsCooler { get; set; } = false;
    }
}
