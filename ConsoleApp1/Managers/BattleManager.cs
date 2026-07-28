using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Managers
{
    // Turn-based battle: every round, all living combatants (party + enemies)
    // act once, in descending Speed order. Party members choose an action
    // (Attack / Skill / Flee); enemies act via simple AI.
    public class BattleManager
    {
        public void StartBattle(List<Character> party, List<Character> enemies)
        {
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("                BATTLE START                ");
            Console.WriteLine("═══════════════════════════════════════════");

            while (party.Any(c => c.IsAlive) && enemies.Any(c => c.IsAlive))
            {
                var turnOrder = party.Concat(enemies)
                                      .Where(c => c.IsAlive)
                                      .OrderByDescending(c => c.Speed)
                                      .ToList();

                foreach (var combatant in turnOrder)
                {
                    if (!combatant.IsAlive) continue;
                    if (!party.Any(c => c.IsAlive) || !enemies.Any(c => c.IsAlive)) break;

                    bool isParty = party.Contains(combatant);
                    var opponents = isParty ? enemies : party;

                    if (isParty)
                        PlayerTurn(combatant, party, opponents);
                    else
                        EnemyTurn(combatant, opponents);
                }
            }

            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine(party.Any(c => c.IsAlive) ? "Party wins!" : "Monsters win!");
            Console.WriteLine("═══════════════════════════════════════════");

            foreach (var enemy in enemies.Where(c => !c.IsAlive))
            {
                Console.WriteLine($"{enemy.Name} dropped:");
                enemy.Loot();
            }
        }

        private void PlayerTurn(Character actor, List<Character> allies, List<Character> opponents)
        {
            Console.WriteLine($"\n{actor.Name}'s turn (HP: {actor.HP})");
            Console.WriteLine("1 - Attack");
            if (actor is Mage mage && mage.Skills.Count > 0)
                Console.WriteLine("2 - Cast Skill");
            Console.WriteLine("0 - Flee");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Attack(actor, opponents);
                    break;
                case "2":
                    if (actor is Mage castingMage)
                        CastSkill(castingMage, allies, opponents);
                    else
                        Attack(actor, opponents);
                    break;
                case "0":
                    Console.WriteLine($"{actor.Name} flees the battle!");
                    allies.Remove(actor);
                    break;
                default:
                    Console.WriteLine("Invalid choice, turn skipped.");
                    break;
            }
        }

        private void EnemyTurn(Character actor, List<Character> opponents)
        {
            var aliveOpponents = opponents.Where(c => c.IsAlive).ToList();
            if (!aliveOpponents.Any()) return;

            var target = aliveOpponents[new Random().Next(aliveOpponents.Count)];
            if (actor is IAttackable attacker)
            {
                attacker.Attack(target);
                ReportIfDefeated(target);
            }
            else
            {
                Console.WriteLine($"{actor.Name} has no way to attack!");
            }
        }

        private void Attack(Character actor, List<Character> opponents)
        {
            var aliveOpponents = opponents.Where(c => c.IsAlive).ToList();
            if (!aliveOpponents.Any()) return;

            Console.WriteLine("Choose target:");
            for (int i = 0; i < aliveOpponents.Count; i++)
                Console.WriteLine($"{i + 1} - {aliveOpponents[i].Name} (HP: {aliveOpponents[i].HP})");

            if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > aliveOpponents.Count)
            {
                Console.WriteLine("Invalid target, turn skipped.");
                return;
            }

            var target = aliveOpponents[idx - 1];
            if (actor is IAttackable attacker)
            {
                attacker.Attack(target);
                ReportIfDefeated(target);
            }
            else
            {
                Console.WriteLine($"{actor.Name} has no way to attack!");
            }
        }

        private void CastSkill(Mage mage, List<Character> allies, List<Character> opponents)
        {
            Console.WriteLine("Choose skill:");
            for (int i = 0; i < mage.Skills.Count; i++)
                Console.WriteLine($"{i + 1} - {mage.Skills[i].GetType().Name} (Mana: {mage.Skills[i].ManaCost})");

            if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > mage.Skills.Count)
            {
                Console.WriteLine("Invalid choice, turn skipped.");
                return;
            }

            var skill = mage.Skills[idx - 1];
            if (mage.Mana < skill.ManaCost)
            {
                Console.WriteLine("Not enough mana! Turn wasted.");
                return;
            }

            bool isHeal = skill is Heal;
            var pool = (isHeal ? allies : opponents).Where(c => c.IsAlive).ToList();
            if (!pool.Any()) return;

            Console.WriteLine(isHeal ? "Choose ally to heal:" : "Choose target:");
            for (int i = 0; i < pool.Count; i++)
                Console.WriteLine($"{i + 1} - {pool[i].Name} (HP: {pool[i].HP})");

            if (!int.TryParse(Console.ReadLine(), out int tIdx) || tIdx < 1 || tIdx > pool.Count)
            {
                Console.WriteLine("Invalid target, turn skipped.");
                return;
            }

            var target = pool[tIdx - 1];
            skill.Use(mage, target);
            if (!isHeal) ReportIfDefeated(target);
        }

        private void ReportIfDefeated(Character target)
        {
            if (!target.IsAlive)
                Console.WriteLine($"{target.Name} has been defeated!");
        }
    }
}
