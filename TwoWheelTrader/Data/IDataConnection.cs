﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWheelTrader.Models.Interfaces;

namespace VehEvalu8.Data
{
    public interface IDataConnection
    {
        IMotorcycle CreateMotorcycle(IMotorcycle motorcycle); 
    }
}
