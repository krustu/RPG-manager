using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Managers
{
    public class CharacterCreator
    {
       // public List<Character> Characters { get; } = new List<Character>();
        public void Classes(List<Character> Characters)
        {
            while (true)
            {

            
            Console.WriteLine("Choose the Class");
            Console.WriteLine("Archer  - 1");
            Console.WriteLine("Elves   - 2");
            Console.WriteLine("Goblin  - 3");
            Console.WriteLine("Mage    - 4");
            Console.WriteLine("Warrior - 5");
            Console.WriteLine("Orc     - 6");
            Console.WriteLine("Back    - 0");
            
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("Name of Character:");
                            string nameA = Console.ReadLine() ?? "";

                            Archer a1 = new Archer(nameA , 100);
                            
                            Characters.Add(a1);

                            Console.WriteLine("Added successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Name of Character:");
                            string nameA = Console.ReadLine() ?? "";

                            Elves a1 = new Elves(nameA, 109);

                            Characters.Add(a1);

                            Console.WriteLine("Added successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("Name of Character:");
                            string nameA = Console.ReadLine() ?? "";

                            Goblin a1 = new Goblin(nameA, 100);

                            Characters.Add(a1);

                            Console.WriteLine("Added successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine("Name of Character:");
                            string nameA = Console.ReadLine() ?? "";

                            Mage a1 = new Mage(nameA, 100);

                            Characters.Add(a1);

                            Console.WriteLine("Added successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine("Name of Character:");
                            string nameA = Console.ReadLine() ?? "";

                             Warrior a1 = new Warrior(nameA, 100);

                            Characters.Add(a1);

                            Console.WriteLine("Added successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "6":
                        try
                        {
                            Console.WriteLine("Name of Character:");
                            string nameA = Console.ReadLine() ?? "";

                            Orc a1 = new Orc(nameA, 100);

                            Characters.Add(a1);

                            Console.WriteLine("Added successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
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
    }
}
