using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Civilian : Character
    {
                public Civilian(string? name, int hp ) : base(name, hp , 1)
        {
            
        }
        public override void Loot()
        {
            Console.WriteLine("+1000XP");
        }
    }
}
