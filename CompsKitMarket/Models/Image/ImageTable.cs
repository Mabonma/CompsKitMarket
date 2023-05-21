using CompsKitMarket.Core.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompsKitMarket.Models.Image
{
    public class ImageTable : BasedModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название файла")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Изображение")]
        public byte[] Content { get; set; }

        [NotMapped]
        public string ContenString => Content == null ? null
            : String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(Content));


        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Расширение файла")]
        public FilesExtensions Type { get; set; }
    }
}
