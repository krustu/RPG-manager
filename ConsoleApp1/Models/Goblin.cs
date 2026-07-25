using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Goblin : Character, IAttackable
    {
        public int Damage { get; set; }
        public Goblin(string? name, int hp) : base(name, hp, 12)
        {
            Damage = 5;
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
