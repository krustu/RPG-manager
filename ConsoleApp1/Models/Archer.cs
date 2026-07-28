using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Archer : Character , IAttackable
    {
        public int Damage { get; set; }
        public Archer(string? name, int hp) : base(name, hp, 10)
        {
            Damage = 9;
            
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
        public override string Description() => "A sharpshooter who prefers to attack from a distance." +
                                                " Fast and elusive.";

        public override string GetFullInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return base.GetFullInfo();
        }

    }
}
