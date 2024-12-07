﻿using Shop_API_Kurlushuk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_API_Kurlushuk.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }

        public int Add(Items item);
    }
}
