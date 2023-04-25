using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using CompsKitMarket.Core.Entities.Enums;

namespace CompsKitMarket.Core.Entities
{
    public class Image : NamedEntity
    {
        public Blob Content { get; set; }
        public FilesExtensions Type { get; set; }
    }
}
