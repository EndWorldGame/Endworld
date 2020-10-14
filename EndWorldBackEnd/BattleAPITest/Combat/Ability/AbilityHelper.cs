using System.Collections.Generic;
using System.Linq;
using MessingAroun.Utils.Dice;

namespace CombatTest.Combat
{
    public static class AbilityHelper
    {
        public static void resolveSingleDamageAbility( string abilityName, BattleFighter attacker, BattleFighter defender, 
            bool physical, List<Die> damageDice, int hitBonus, int damageBonus)
        {
            //Initialize Roller and Add Dice
            DiceRoller roller = new DiceRoller();
            roller.addDice( DiceBag.get(10) );
            
            //Resolve attack roll and attack calculations
            int attackRoll = roller.rollDice();
            int attackValue = attackRoll + hitBonus;
            BattleConsoleUI.printAttackRollResults(attacker.Name, attackRoll, hitBonus, attackValue, attacker.PlayerChar);
            
            //Resolve Defense roll and defense calculations
            int defenseRoll = roller.rollDice();
            int defenseValue;
            if (physical)
            {
                defenseValue = defenseRoll + defender.Armor.PhysicalResistance;
                BattleConsoleUI.printDefenseRollResults(defender.Name, defenseRoll, defender.Armor.PhysicalResistance, defenseValue, defender.PlayerChar);
            }
            else
            {
                defenseValue = defenseRoll + defender.Armor.EnergyResistance;
                BattleConsoleUI.printDefenseRollResults(defender.Name, defenseRoll, defender.Armor.EnergyResistance, defenseValue, defender.PlayerChar);
            }

            if (attackValue > defenseValue)
            {
                //Implement damage calculator here
                roller = new DiceRoller();
                roller.addDice(damageDice);
                int damageRoll = roller.rollDice();
                int damage = damageRoll + damageBonus;
                if (damage > defender.CurrentHealth)
                {
                    damage = defender.CurrentHealth;
                }
                BattleConsoleUI.printAttackSuccessMessage(attacker.Name, abilityName,
                    damage, defender.Name, damageRoll, damageBonus, attacker.PlayerChar, physical);
                
                //Implement damage resolver here
                defender.CurrentHealth = (defender.CurrentHealth - damage);
            }
            else
            {
                BattleConsoleUI.printAttackFailMessage(defender.Name, defender.PlayerChar);
            }
        }
        
        public static void resolveMultiDamageAbility( string abilityName, BattleFighter attacker, BattleFighter defender, 
            bool physical, List<Die> damageDice, int hitBonus, int damageBonus, int times, Battle battle, bool diminishing )
        {
            //Initialize Roller and Add Dice
            DiceRoller roller = new DiceRoller();
            roller.addDice( DiceBag.get(10) );
            for (int i = 0; i < times; i++)
            {
                if (diminishing && i > 0)
                {
                    hitBonus -= 1;
                }
                //Resolve attack roll and attack calculations
                int attackRoll = roller.rollDice();
                int attackValue = attackRoll + hitBonus;
                BattleConsoleUI.printAttackRollResults(attacker.Name, attackRoll, hitBonus, attackValue, attacker.PlayerChar);
            
                //Resolve Defense roll and defense calculations
                int defenseRoll = roller.rollDice();
                int defenseValue;
                if (physical)
                {
                    defenseValue = defenseRoll + defender.Armor.PhysicalResistance;
                    BattleConsoleUI.printDefenseRollResults(defender.Name, defenseRoll, defender.Armor.PhysicalResistance, defenseValue, defender.PlayerChar);
                }
                else
                {
                    defenseValue = defenseRoll + defender.Armor.EnergyResistance;
                    BattleConsoleUI.printDefenseRollResults(defender.Name, defenseRoll, defender.Armor.EnergyResistance, defenseValue, defender.PlayerChar);
                }

                if (attackValue > defenseValue)
                {
                    //Implement damage calculator here
                    roller = new DiceRoller();
                    roller.addDice(damageDice);
                    int damageRoll = roller.rollDice();
                    int damage = damageRoll + damageBonus;
                    if (damage > defender.CurrentHealth)
                    {
                        damage = defender.CurrentHealth;
                    }
                    BattleConsoleUI.printAttackSuccessMessage(attacker.Name, abilityName,
                        damage, defender.Name, damageRoll, damageBonus, attacker.PlayerChar, physical);
                
                    //Implement damage resolver here
                    defender.CurrentHealth = (defender.CurrentHealth - damage);
                    battle.checkForDeadFighters();
                    if (defender.CurrentHealth == 0)
                    {
                        break;
                    }
                }
                else
                {
                    BattleConsoleUI.printAttackFailMessage(defender.Name, defender.PlayerChar);
                }   
            }
        }

        public static void resolveAOEDamageAbility( string abilityName, BattleFighter attacker, 
            bool physical, List<Die> damageDice, int hitBonus, int damageBonus, Battle battle)
        {
            foreach (BattleFighter defender in battle.AllFighters.Where(x => !x.PlayerChar).ToList())
            {
                //Initialize Roller and Add Dice
                DiceRoller roller = new DiceRoller();
                roller.addDice( DiceBag.get(10) );
                
                //Resolve attack roll and attack calculations
                int attackRoll = roller.rollDice();
                int attackValue = attackRoll + hitBonus;
                BattleConsoleUI.printAttackRollResults(attacker.Name, attackRoll, hitBonus, attackValue, attacker.PlayerChar);
                
                //Resolve Defense roll and defense calculations
                int defenseRoll = roller.rollDice();
                int defenseValue;
                if (physical)
                {
                    defenseValue = defenseRoll + defender.Armor.PhysicalResistance;
                    BattleConsoleUI.printDefenseRollResults(defender.Name, defenseRoll, defender.Armor.PhysicalResistance, defenseValue, defender.PlayerChar);
                }
                else
                {
                    defenseValue = defenseRoll + defender.Armor.EnergyResistance;
                    BattleConsoleUI.printDefenseRollResults(defender.Name, defenseRoll, defender.Armor.EnergyResistance, defenseValue, defender.PlayerChar);
                }

                if (attackValue > defenseValue)
                {
                    //Implement damage calculator here
                    roller = new DiceRoller();
                    roller.addDice(damageDice);
                    int damageRoll = roller.rollDice();
                    int damage = damageRoll + damageBonus;
                    if (damage > defender.CurrentHealth)
                    {
                        damage = defender.CurrentHealth;
                    }
                    BattleConsoleUI.printAttackSuccessMessage(attacker.Name, abilityName,
                        damage, defender.Name, damageRoll, damageBonus, attacker.PlayerChar, physical);
                    
                    //Implement damage resolver here
                    defender.CurrentHealth = (defender.CurrentHealth - damage);
                }
                else
                {
                    BattleConsoleUI.printAttackFailMessage(defender.Name, defender.PlayerChar);
                }
            }
        }
    }
}