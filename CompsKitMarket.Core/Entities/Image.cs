using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using CompsKitMarket.Core.Entities.Enums;
using CompsKitMarket.Core.Entities.Kits;

namespace CompsKitMarket.Core.Entities
{
    public class Image : NamedEntity
    {
        public byte[] Content { get; set; }
        public FilesExtensions Type { get; set; }
        public int PartId { get; set; }
        public Part Part { get; set; }
    }
}
