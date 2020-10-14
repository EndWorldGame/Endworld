using System;
using System.Collections.Generic;
using System.Linq;
using CombatTest.Combat.Action;

namespace CombatTest.Combat
{
    public class BattleConsoleUI
    {
        public static void printDeathMessage(Fighter fighter)
        {
        }

        public static void showCombatActions(List<IAction> actions)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int _place = 1;
            actions.ForEach(action => { Console.WriteLine("{0}. {1}", _place++, action.Name()); });
        }

        public static void printBlockLine()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------");
        }
        
        public static void printFighters(Battle battle, int turn)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (turn == 0)
            {
                printBlockLine();
            }
            int _place = 0;
            Console.WriteLine("Combat Order");
            printBlockLine();
            battle.AllFighters.ForEach(
                x =>
                {
                    _place++;
                    if (x.PlayerChar)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine("{0}. {1} ({2}/{3})", _place, x.Name, x.CurrentHealth, x.BattleStats().Health);
                }
            );
            printBlockLine();
        }

        public static void setPlayerColor(bool player)
        {
            if (player)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }

        public static void printFighterTurn(BattleFighter fighter, int turn)
        {
            setPlayerColor(fighter.PlayerChar);
            Console.WriteLine(fighter.Name + " ({0}/{1}) [{2}/{3}] PL {4} Turn {5}.", 
                fighter.CurrentHealth, fighter.BattleStats().Health, fighter.CurrentEnergy,
                fighter.Stats().Energy, fighter.PowerLevel(), turn);
            printBlockLine();
        }

        public static void printBattleOverMessage(bool win)
        {
            if (win)
            {
                Console.WriteLine("You have Won! Type any character to exit.");
            }
            else
            {
                Console.WriteLine("You have lost! Type any character to exit.");
            }
            Console.ReadLine();
            printBlockLine();
        }

        public static void printAttackRollResults(string name, int attackRoll, int hitBonus, int attackValue, bool player)
        {
            setPlayerColor(player);
            Console.WriteLine("{0} <Attack Roll>: {1} + {2} = {3}", name, attackRoll, 
                hitBonus, attackValue);
        }
        
        public static void printDefenseRollResults(string name, int defenseRoll, int hitBonus, int defenseValue, bool player)
        {
            setPlayerColor(player);
            Console.WriteLine("{0} <Defense Roll>: {1} + {2} = {3}", name, defenseRoll, 
                hitBonus, defenseValue);
            printBlockLine();
        }

        public static void printAttackSuccessMessage(string name, string weaponName, int damage, string defenderName, 
            int damageRoll, int damageBonus, bool player, bool physical)
        {
            string damageType = "";
            if (physical)
            {
                damageType = "Physical";
            }
            else
            {
                damageType = "Energy";
            }
            setPlayerColor(player);
            Console.WriteLine("Attack success! {0} < -- {1} -- > deals {2} {3} damage to {4} ({5} + {6})", name, weaponName,
                damage, damageType, defenderName, damageRoll, damageBonus);
            printBlockLine();
            Console.ReadLine();
        }

        public static void printAttackFailMessage(string defenderName, bool player)
        {
            setPlayerColor(player);
            Console.WriteLine("Attack failed. {0} successfully defended.", defenderName);
            printBlockLine();
            Console.ReadLine();
        }

        public static int showEnemyTargets(Battle battle)
        {
            bool validInput = false;
            int choice = 1;
            while (!validInput)
            {
                int _enumerator = 1;
                BattleConsoleUI.printBlockLine();
                Console.WriteLine("Targets");
                BattleConsoleUI.printBlockLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                battle.AllFighters.Where(x => !x.PlayerChar).ToList().ForEach(x =>
                {
                    Console.WriteLine("{0}. {1} PL {4} ({2}/{3})", _enumerator, x.Name, x.CurrentHealth,
                        x.BattleStats().Health, x.PowerLevel());
                    _enumerator++;
                });
                BattleConsoleUI.printBlockLine();
                validInput = (Int32.TryParse(Console.ReadLine(), out choice) && (choice > 0 && choice < _enumerator));
                if (!validInput)
                {
                    Console.WriteLine("Invalid choice, please choose a number between 1 and {0}", _enumerator-1);
                }
            }
            return choice;
        }
        
        public static int showAllyTargets(Battle battle)
        {
            bool validInput = false;
            int choice = 1;
            while (!validInput)
            {
                int _enumerator = 1;
                BattleConsoleUI.printBlockLine();
                Console.WriteLine("Targets");
                BattleConsoleUI.printBlockLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                battle.AllFighters.Where(x => x.PlayerChar).ToList().ForEach(x =>
                {
                    Console.WriteLine("{0}. {1} PL {4} ({2}/{3})", _enumerator, x.Name, x.CurrentHealth,
                        x.BattleStats().Health, x.PowerLevel());
                    _enumerator++;
                });
                BattleConsoleUI.printBlockLine();
                validInput = (Int32.TryParse(Console.ReadLine(), out choice) && (choice > 0 && choice < _enumerator));
                if (!validInput)
                {
                    Console.WriteLine("Invalid choice, please choose a number between 1 and {0}", _enumerator-1);
                }
            }
            return choice - 1;
        }
        
    }
}