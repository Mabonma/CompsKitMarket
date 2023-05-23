using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompsKitMarket.Models.Part
{
    public class PartTable : BasedModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Обязательнео поле")]
        [Display(Name = "Производитель")]
        public int ManufacturerId { get; set; }

        [NotMapped]
        [Display(Name = "Произвоидтель")]
        public string ManufacturerName { get; set; }

        [NotMapped]
        public byte[] Data { get; set; }

        [NotMapped]
        public string DataFormat => Data == null ? null
            : string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(Data));
    }
}
