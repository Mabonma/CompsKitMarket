using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Core.Entities.Orders;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CompsKitMarket.Models
{
    public class HsdModel : BasedModel/*, ICloneable*/
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Производитель")]
        public string ManufacturerName { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле")]
        public int ManufacturerId { get; set; }

        [NotMapped]
        public bool IsNew => Id == 0;

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Картинка")]
        public IFormFile Image { get; set; }

        [NotMapped]
        public byte[] Data { get; set; }
        [NotMapped]
        public string DataFormat => Data == null ? null
            : String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(Data));

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Тип жёсткого диска")]
        public HsdTypes Type { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Интерфейс")]
        public HsdConnections Connections { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Объём")]
        public int Vol { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Форм-фактор")]
        public HsdForms Form { get; set; }

        public bool Deleted { get; set; }

        //public object Clone()
        //{
        //    return this.MemberwiseClone();
        //}
    }
}
