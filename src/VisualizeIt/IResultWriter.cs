﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizeIt
{
    public interface IResultWriter
    {
        void Write(string value);
    }
}
