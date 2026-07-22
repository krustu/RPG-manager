using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    
    public class Mage : Character, IAttackable
    {
        public int Damage { get; set; }
        public int Mana { get; set; }
        public List<ICastable> Skills { get; set; }
        public Mage(string? name, int hp /* int mana*/) : base(name, hp)
        {
            //Mana = mana;
            Mana = 100;
            Damage = 15;
            Skills = new List<ICastable>()
            {

             new FireBall(),
             new Heal()

            };
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
    public class FireBall : ICastable
    {
        public int ManaCost => 12;
        public void Use(Mage mage, Character character)
        {
            if (mage.Mana < ManaCost)
            {
                Console.WriteLine("Not enough mana!");
            }
            mage.Mana -= ManaCost;

            int dmg = 30;
            character.HP -= dmg;
            Console.WriteLine($"{mage.Name} throw Fireball! {dmg} damage!" );
        }
    }
    public class Heal : ICastable
    {
        public int ManaCost => 20;
        public void Use(Mage mage, Character character)
        {
            if (mage.Mana < ManaCost)
            {
                Console.WriteLine("Not enough mana!");
            }
            mage.Mana -= ManaCost;
            int heal = 20;
            mage.HP += heal;
            Console.WriteLine($"{mage.Name} Healed {heal} hp ");
        }
    }
}

