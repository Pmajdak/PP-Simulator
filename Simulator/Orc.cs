using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int huntCount;
    private int rage = 1;

    public int Rage
    {
        get => rage;
        init { rage = Validator.Limiter(value, 0, 10); }
    }

    public override int Power => 7 * Level + 3 * Rage;

    public Orc() { }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        if (++huntCount >= 3 && rage < 10)
        {
            rage++;
            huntCount = 0;
        }
    }

    public override void SayHi() =>
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

    public override string Info => $"{Name} [{Level}][{Rage}]";
}
