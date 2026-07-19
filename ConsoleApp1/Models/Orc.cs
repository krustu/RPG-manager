using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Orc : Character, IAttackable
    {
        public int Damage { get; set; }
        public Orc(string? name, int hp) : base(name, hp)
        { 

        }
        public void Attack(IDamageable target)
        {
            // Implement attack logic here
            Console.WriteLine($"{Name} attacks {target.Name}!");
            target.TakeDamage(Damage);
        }
        public override void Loot()
        {
            Console.WriteLine("+1000XP");
        }
    }
}
