﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionCalculator.DataAccess.Interfaces
{
    public interface ICreate<out T>
    {
        T CreateItem();
    }
}
