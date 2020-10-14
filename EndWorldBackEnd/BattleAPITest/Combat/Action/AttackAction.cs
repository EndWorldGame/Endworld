using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using MessingAroun.Utils.Dice;

namespace CombatTest.Combat.Action
{
    public class AttackAction : IAction
    {
        public string Name()
        {
            return "Attack";
        }

        public bool Execute(BattleFighter user, Battle battle)
        {
            useAttack(user, battle);
            return false;
        }
        
        public void Execute(BattleFighter user, BattleFighter target, Battle battle)
        {
            attack(user, target, user.Weapon.Physical);
            battle.checkForDeadFighters();
        }
        
        public void useAttack(BattleFighter user, Battle battle)
        {
            BattleFighter target = chooseTarget( battle );
            attack(user, target, user.Weapon.Physical);
            battle.checkForDeadFighters();
        }

        public BattleFighter chooseTarget( Battle battle)
        {
            List<BattleFighter> targets = battle.AllFighters.Where(x => !x.PlayerChar).ToList();
            return targets[BattleConsoleUI.showEnemyTargets(battle) - 1];
        }

        public void attack(BattleFighter attacker, BattleFighter defender, bool physical)
        {
            //Initialize Roller and Add Dice
            DiceRoller roller = new DiceRoller();
            roller.addDice(DiceBag.get(10));
            
            //Resolve attack roll and attack calculations
            int attackRoll = roller.rollDice();
            int attackValue = attackRoll + attacker.Weapon.HitBonus;
            BattleConsoleUI.printAttackRollResults(attacker.Name, attackRoll, attacker.Weapon.HitBonus, attackValue, attacker.PlayerChar);
            
            //Resolve Defense roll and defense calculations
            int defenseRoll = roller.rollDice();
            int defenseBonus = 0;
            int defenseValue;
            if (physical)
            {
                defenseBonus = defender.Armor.PhysicalResistance;
                defenseValue = defenseRoll + defenseBonus;
            }
            else
            {
                defenseBonus = defender.Armor.EnergyResistance;
                defenseValue = defenseRoll + defenseBonus;
                
            }
            BattleConsoleUI.printDefenseRollResults(defender.Name, defenseRoll, defenseBonus, defenseValue, defender.PlayerChar);

            if (attackValue > defenseValue)
            {
                //Implement damage calculator here
                roller = new DiceRoller();
                roller.addDice(attacker.Weapon.DamageDice);
                int damageRoll = roller.rollDice();
                int damage = damageRoll + attacker.Weapon.DamageBonus;
                if (damage > defender.CurrentHealth)
                {
                    damage = defender.CurrentHealth;
                }
                BattleConsoleUI.printAttackSuccessMessage(attacker.Name, attacker.Weapon.Name,
                    damage, defender.Name, damageRoll, attacker.Weapon.DamageBonus, attacker.PlayerChar, attacker.Weapon.Physical);
                
                //Implement damage resolver here
                defender.CurrentHealth -= damage;
            }
            else
            {
                BattleConsoleUI.printAttackFailMessage(defender.Name, defender.PlayerChar);
            }
        }
    }
}