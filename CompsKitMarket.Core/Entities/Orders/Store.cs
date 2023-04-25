﻿namespace CompsKitMarket.Core.Entities.Orders
{
    public class Store : NamedEntity
    {

        public string Description { get; set; }

        public string WorkMode { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Mail { get; set; }

        public bool Deleted { get; set; }
    }

}
