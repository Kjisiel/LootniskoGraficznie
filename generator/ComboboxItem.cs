﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator
{
    /// <summary>
    /// Klasa wykorzystywana do list rozwijalnych w interfejsie graficznym.
    /// </summary>
    class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public double Order { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
