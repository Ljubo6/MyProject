﻿using ICar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Intrfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
}
