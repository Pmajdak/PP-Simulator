﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Animals
{
    private string description = "Description";
    public string Description
    {
        get { return description; }
        init { description = Validator.Shortener(value, 3, 15, '#'); }
    }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}

