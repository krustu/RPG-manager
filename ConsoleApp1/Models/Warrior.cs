using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Warrior : Character , IAttackable
    {
        public int Damage { get; set; }
        public Warrior(string? name, int hp) : base(name, hp, 5)
        {
            Damage = 10;
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
        public override string Description() => "⚔️ A true fighter with a heavy sword and reliable armor. " +
                                                "Resilient and powerful in close combat.";

        public override string GetFullInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return base.GetFullInfo();
        }
    }
}
