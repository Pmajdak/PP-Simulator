using System;
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
        init
        {
            if (value.Length > 15)
            {
                value = value.Substring(0, 15).TrimEnd();
            }
            value = value.Trim();
            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }
            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }
            description = value;
        }
    }

    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
}

