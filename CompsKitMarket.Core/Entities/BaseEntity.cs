﻿using System.ComponentModel.DataAnnotations;

namespace CompsKitMarket.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
