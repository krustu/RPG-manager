using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Managers
{
    public class GameManager
    {
        private List<Character> Characters = new();
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine(" ~ Start Game            - 1");
                Console.WriteLine(" ~ All Chararcters       - 2");
                Console.WriteLine(" ~ Discritption          - 3");
                Console.WriteLine(" ~ Create the character  - 4");
                Console.WriteLine(" ~ Exit                  - 0");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        StartGame(); 
                        break;
                    case "2":
                        Info();
                        break;
                    case "3":
                        Discritption();
                        break;
                    case "4":
                        
                         Create();  
                        break;
                    case "0":
                        Console.WriteLine("Thank you for playing game. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
            private void StartGame()
        {
            while (true)
            {
                Console.WriteLine("Game");
                Console.ReadKey();
            }

        }
            private void Info()
        {
            while (true)
            {
                Console.WriteLine("info");
                foreach (Character character in Characters)
                {
                    Console.WriteLine($"{character.Name} | HP: {character.HP}");

                    if (character is IAttackable attacker)
                    {
                        Console.WriteLine($"Damage: {attacker.Damage}");
                    }
                }
               
                Console.ReadKey();
                break;
            }
        }
            private void Discritption()
        {
            while (true)
            {
                Console.WriteLine("dis");
                Console.ReadKey();
            }
        }
            private void Create()
        {

            CharacterCreator creator = new CharacterCreator();
            creator.Classes(Characters);
        }
    }
}

