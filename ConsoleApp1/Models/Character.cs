using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Character : IDamageable , ILootable
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

        public virtual void Info()
        {
            Console.WriteLine($"name :{Name}");
            Console.WriteLine($"HP - {HP}");
            Console.WriteLine($"Speed - {Speed}");
        }
    }
}
