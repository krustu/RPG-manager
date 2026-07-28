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

        // we can use this list to store the skills of the mage 
        // alse can added list like a parameter in the constructor to add skills when creating a mage
        public Mage(string? name, int hp) : base(name, hp, 8)
        {
            //Mana = mana;
            Mana = 70;
            Damage = 6;
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

        public override string Description() => "A wise wizard who wields powerful spells. " +
                                                " Weak in melee, but deadly at range.";

        public override string GetFullInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return base.GetFullInfo();
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
                return;
            }
            mage.Mana -= ManaCost;

            int dmg = 30;
            character.TakeDamage(dmg);
            Console.WriteLine($"{mage.Name} throw Fireball at {character.Name}! {dmg} damage!" );
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
                return;
            }
            mage.Mana -= ManaCost;
            int heal = 20;
            character.HP += heal;
            Console.WriteLine($"{mage.Name} healed {character.Name} for {heal} hp ");
        }
    }
}

