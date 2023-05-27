using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Core.Migrations;
using CompsKitMarket.Models.Part;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CompsKitMarket.Models.Ram
{
    public class RamTable : PartTable
    {
        [Display(Name = "Тип")]
        public string TypeName { get; set; }

        [Display(Name = "Общий объем")]
        public double Vol { get; set; }

        [Display(Name = "Набор")]
        public byte Count { get; set; }

        [Display(Name = "Частота")]
        public int Freq { get; set; }

        [Display(Name = "Тайминги")]
        public string Timings { get; set; }
    }
}
