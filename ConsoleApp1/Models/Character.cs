using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public abstract class Character : IDamageable , ILootable , IDescription 
    {
        public string? Name { get; set; }
        public int HP { get; set; }
        public int Speed { get; private set; }
        // public int lvl { get; set; }
        public bool IsAlive => HP > 0;

        public virtual void GetLoot()
        {
            {

                if (IsAlive)
                {
                    throw new Exception($"{Name} is still alive, cannot loot");
                }
                Loot();
            }
            
        }
        public virtual void Loot()
        {
            Console.WriteLine($"{Name} dropped : 2-Golds , +2000XP");
        }
        public virtual void TakeDamage(int damage)
        {
            HP -= damage;
        }

        public Character(string? name , int hp , int speed)
        {
            Name = name;
            HP = hp;
            Speed = speed;
        }

        public virtual string Description()
        {
            return $"Name: {Name}, HP: {HP}, Speed: {Speed}";
        }

        public virtual string GetFullInfo()
        {
            return $@"
                   ╔═══════════════════════╗
                   ║   {Description()}     ║
                   ╚═══════════════════════╝";
        }
    }
}
//$"Name: {Name}, HP: {HP}, Speed: {Speed}";