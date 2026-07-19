using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    
    public class Mage : Character, IAttackable
    {
        public int Damage { get; set; }
        public Mage(string? name, int hp) : base(name, hp)
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
         







        public List<ICastable> Skills = new List<ICastable>()
    {
        new FireBall(),
        new Heal()
    };

    }
    public class FireBall : ICastable
    {
        public void Use(Mage mage, Character character)
        {
            int dmg = 30;
            character.HP -= dmg;
            Console.WriteLine($"{mage.Name} throw Fireball! {dmg} damage!" );
        }
    }
    public class Heal : ICastable
    {
        public void Use(Mage mage, Character character)
        {
            int heal = 20;
            mage.HP += heal;
            Console.WriteLine($"{mage.Name} Healed {heal} hp ");
        }
    }
}

