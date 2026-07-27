using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp1.Managers.BaseCharacter;

namespace ConsoleApp1.Managers
{
    public class GameManager
    {
        private List<Character> Characters = new();
       
        private List<Character> BaseCharacters = new();
        public void Run()
        {
            BaseCharacter baseCharacter = new BaseCharacter();
            baseCharacter.browlers(BaseCharacters);
            while (true)
            {
               // Console.Clear();
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("             Menu                          ");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine(" ~ Start Game            - 1");
                Console.WriteLine(" ~ All Chararcters       - 2");
                Console.WriteLine(" ~ Discritption          - 3");
                Console.WriteLine(" ~ Create the character  - 4");
                Console.WriteLine(" ~ Exit                  - 0");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        //StartGame(); 
                        Console.WriteLine("Nothing here, pls come back later");
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
                BattleManager battle = new BattleManager();
                battle.StartBattle(Characters , Characters);

                Console.ReadKey();
            }

        }
            private void Info()
        {
            while (true)
            {
               
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("             Menu Characters               ");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine(" ~    My Characters      - 1");
                Console.WriteLine(" ~    Base Characters    - 2");
                Console.WriteLine(" ~    Description        - 3");
                Console.WriteLine(" ~    Back               - 4");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("INFO");
                            foreach (Character character in Characters)
                            {
                                Console.WriteLine($"{character.Name} | HP: {character.HP}");

                                if (character is IAttackable attacker)
                                {
                                    Console.WriteLine($"Damage: {attacker.Damage}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "2":
                        try
                        {
                            BaseCharacter baseCharacter = new BaseCharacter();
                            baseCharacter.DisplayCharacters(BaseCharacters);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "3":
                        try
                        {

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "4":
                        {
                            return;
                        }
                        
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
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

