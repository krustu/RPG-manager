using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Elves : Character , IAttackable
    {
        public int Damage { get; set; }
        public Elves(string? name, int hp) : base(name, hp, 7 )
        {
            Damage = 8;
            
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
