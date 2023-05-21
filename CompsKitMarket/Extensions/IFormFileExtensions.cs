using CompsKitMarket.Core.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CompsKitMarket.Extensions
{
    public static class IFormFileExtensions
    {
        public static byte[] ToByteArray(this IFormFile formFile)
        {
            if (formFile == null) return null;

            using var memoryStream = new System.IO.MemoryStream();
            formFile.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public static FilesExtensions GetExtension(this IFormFile formFile)
        {
            if (formFile == null) return 0;

            var extension = formFile.ContentType.Split('/')[1].ToLower();
            return extension switch
            {
                "png" => FilesExtensions.Png,
                "jpg" => FilesExtensions.Jpg,
                "gif" => FilesExtensions.Gif,
                "jpeg" => FilesExtensions.Jpeg,
                _ => 0,
            };
        }
    }
}
