using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Managers
{
    public class BattleManager
    {
        public void StartBAttle(List<Character> party, List<Character> Monsters)
        {
           while(party.Exists(x => x.IsAlive) && Monsters.Exists(x => x.IsAlive))
            {
                foreach (var character in party)
                {
                    if (character.IsAlive)
                    {
                        var target = Monsters.Find(x => x.IsAlive);
                        if (target != null)
                        {
                            character.TakeDamage(target.Speed);
                            Console.WriteLine($"{character.Name} attacks {target.Name} for {target.Speed} damage.");
                            if (!target.IsAlive)
                            {
                                Console.WriteLine($"{target.Name} has been defeated!");
                            }
                        }
                    }
                }
                foreach (var monster in Monsters)
                {
                    if (monster.IsAlive)
                    {
                        var target = party.Find(x => x.IsAlive);
                        if (target != null)
                        {
                            monster.TakeDamage(target.Speed);
                            Console.WriteLine($"{monster.Name} attacks {target.Name} for {target.Speed} damage.");
                            if (!target.IsAlive)
                            {
                                Console.WriteLine($"{target.Name} has been defeated!");
                            }
                        }
                    }
                }
            }
            if (party.Exists(x => x.IsAlive))
            {
                Console.WriteLine("Party wins!");
            }
            else
            {
                Console.WriteLine("Monsters win!");
            }


        }


    }
}
