# RPG-manager
A console-based RPG battle system in C# — character creation, combat, loot, and interfaces-driven design.

## Features
- Character hierarchy: `Warrior`, `Mage`, `Archer` (and monsters: `Goblin`, `Orc`, `Human`)
- Interface-driven combat system (`IAttackable`, `IDamageable`, `ICastable`, `ILootable`)
- Party management, turn-based fights, and loot collection
- Exception handling for invalid actions (attacking while dead, looting a living character, etc.)
- (Planned) Save/load character data to file

## Why this project
Built to practice inheritance, polymorphism, interfaces, and clean object-oriented 
design in C#, moving from small isolated exercises toward a single, growing system.
