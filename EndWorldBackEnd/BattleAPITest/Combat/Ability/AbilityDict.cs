using System;
using System.Collections.Generic;
using System.Linq;
using MessingAroun.Utils.Dice;

namespace CombatTest.Combat
{
    // public class AbilityDict
    // {
    //     public static Ability getAbility(string abilityName)
    //     {
    //         switch (abilityName)
    //         {
    //             case "Ice Beam":
    //                 return new IceBeamAbility();
    //             default:
    //                 return null;
    //         }
    //     }
    // }
    
    public class CommandoBombAbility: Ability
    {
        private static readonly string _name = "Commando Bomb";
        private static readonly int _cost = 6;
        public string Name()
        {
            return _name;
        }

        public void Execute(BattleFighter user, Battle battle)
        {
            DiceRoller roller = new DiceRoller();
            roller.addDice(DiceBag.get(4));
            int result = roller.rollDice();
            
            AbilityHelper.resolveAOEDamageAbility(_name, user, true, 
                new List<Die>(){ DiceBag.get(4) }, 5, 2, battle);
            if (result == 4)
            {
                BattleConsoleUI.printBlockLine();
                Console.WriteLine("{0}'s Commando Bomb caused a secondary explosion!", user.Name);
                BattleConsoleUI.printBlockLine();
                AbilityHelper.resolveAOEDamageAbility(_name, user, true, 
                    new List<Die>(){ DiceBag.get(4) }, 5, 0, battle);
            }
        }

        public int EnergyCost()
        {
            return _cost;
        }
    }
    
    public class IceBeamAbility: Ability
         {
             private static readonly string _name = "Ice Beam";
             private static readonly int _cost = 3;
             public string Name()
             {
                 return _name;
             }
     
             public void Execute(BattleFighter user, Battle battle)
             {
                 AbilityHelper.resolveSingleDamageAbility(_name, user,
                     battle.AllFighters.Where(x => !x.PlayerChar).ToList()[BattleConsoleUI.showEnemyTargets(battle) - 1], 
                     true, new List<Die>(){ DiceBag.get(6) }, (user.BattleStats().Power), (1+user.BattleStats().Power));
             }
     
             public int EnergyCost()
             {
                 return _cost;
             }
         }

    public class DoubleFlashbackAbility : Ability
    {
        private static readonly string _name = "Double Flashback";
        private static readonly int _cost = 4;
        public string Name()
        {
            return _name;
        }

        public void Execute(BattleFighter user, Battle battle)
        {
            for (int i = 0; i < 2; i++)
            {
                List<BattleFighter> allies = battle.AllFighters.Where(x => x.PlayerChar).ToList();
                BattleFighter target = allies[BattleConsoleUI.showAllyTargets(battle)];

                DiceRoller roller = new DiceRoller();
                roller.addDice(DiceBag.get(4));
                int healRoll = roller.rollDice();
                int healAmount = healRoll;

                int healthMissing = target.Stats().Health - target.CurrentHealth;
                if (healRoll > healthMissing)
                {
                    healAmount = healthMissing;
                }

                target.CurrentHealth += healAmount;
                Console.WriteLine("{0} uses Flashback and heals {1} for {2} Health", user.Name, target.Name,
                    healAmount);
                BattleConsoleUI.printBlockLine();
            }
        }

        public int EnergyCost()
        {
            return _cost;
        }
    }
    public class FlashbackAbility : Ability
    {
        private static readonly string _name = "Flashback";
        private static readonly int _cost = 3;
        public string Name()
        {
            return _name;
        }

        public void Execute(BattleFighter user, Battle battle)
        {
            List<BattleFighter> allies = battle.AllFighters.Where(x => x.PlayerChar).ToList();
            BattleFighter target = allies[BattleConsoleUI.showAllyTargets(battle)];
            
            DiceRoller roller = new DiceRoller();
            roller.addDice(DiceBag.get(6));
            int healRoll = roller.rollDice();
            int healAmount = healRoll + 1;

            int healthMissing = target.BattleStats().Health - target.CurrentHealth;
            if (healAmount > healthMissing)
            {
                healAmount = healthMissing;
            }

            target.CurrentHealth += healAmount;
            Console.WriteLine("{0} uses Flashback and heals {1} for {2} Health", user.Name, target.Name, healAmount);
            BattleConsoleUI.printBlockLine();
        }

        public int EnergyCost()
        {
            return _cost;
        }
    }
    
    public class FireBlastAbility: Ability
    {
        private static readonly string _name = "Fire Blast";
        private static readonly int _cost = 3;
        public string Name()
        {
            return _name;
        }

        public void Execute(BattleFighter user, Battle battle)
        {
            AbilityHelper.resolveSingleDamageAbility(_name, user,
                battle.AllFighters.Where(x => !x.PlayerChar).ToList()[BattleConsoleUI.showEnemyTargets(battle) - 1], 
                false, new List<Die>(){ DiceBag.get(8) }, (user.BattleStats().Power), (user.BattleStats().Power));
        }

        public int EnergyCost()
        {
            return _cost;
        }
    }
    
    public class QuickBoomerangAbility: Ability
    {
        private static readonly string _name = "Quick Boomerang";
        private static readonly int _cost = 3;
        public string Name()
        {
            return _name;
        }

        public void Execute(BattleFighter user, Battle battle)
        {
            AbilityHelper.resolveSingleDamageAbility(_name, user,
                battle.AllFighters.Where(x => !x.PlayerChar).ToList()[BattleConsoleUI.showEnemyTargets(battle) - 1], 
                true, new List<Die>(){  DiceBag.get(4), DiceBag.get(4) }, 
                (user.BattleStats().Speed), (user.BattleStats().Speed));
        }

        public int EnergyCost()
        {
            return _cost;
        }
    }

    public class TriBeamAbility: Ability
    {
        private static readonly string _name = "Tri Beam";
        private static readonly int _cost = 3;
        public string Name()
        {
            return _name;
        }

        public void Execute(BattleFighter user, Battle battle)
        {
            for (int i = 0; i < 3; i++)
            {
                AbilityHelper.resolveSingleDamageAbility(_name, user,
                    battle.AllFighters.Where(x => !x.PlayerChar).ToList()[BattleConsoleUI.showEnemyTargets(battle) - 1], 
                    false, new List<Die>(){ DiceBag.get(4) }, (user.BattleStats().Power), 1);
                battle.checkForDeadFighters();
            }
        }

        public int EnergyCost()
        {
            return _cost;
        }
    }

    public class SnipeAbility : Ability
    {
        private static readonly string _name = "Snipe";
        private static readonly int _cost = 3;
        public string Name()
        {
            return _name;
        }

        public void Execute(BattleFighter user, Battle battle)
        {
            AbilityHelper.resolveSingleDamageAbility(_name, user,
                battle.AllFighters.Where(x => !x.PlayerChar).ToList()[BattleConsoleUI.showEnemyTargets(battle) - 1], 
                true, user.Weapon.DamageDice, user.Weapon.HitBonus+2, user.Weapon.DamageBonus+1);
        }

        public int EnergyCost()
        {
            return _cost;
        }
    }

    public class RapidFireAbility : Ability
    {
        private static readonly string _name = "Rapid Fire";
        private static readonly int _cost = 4;
        public string Name()
        {
            return _name;
        }

        public void Execute(BattleFighter user, Battle battle)
        {
            AbilityHelper.resolveMultiDamageAbility(_name, user,
                battle.AllFighters.Where(x => !x.PlayerChar).ToList()[BattleConsoleUI.showEnemyTargets(battle) - 1], 
                true, user.Weapon.DamageDice, (user.Weapon.HitBonus), (user.Weapon.DamageBonus), 3, battle, true);
        }

        public int EnergyCost()
        {
            return _cost;
        }
    }
    
    public class FireStormAbility : Ability
    {
        private static readonly string _name = "Fire Storm";
        private static readonly int _cost = 5;
        public string Name()
        {
            return _name;
        }

        public void Execute(BattleFighter user, Battle battle)
        {
            AbilityHelper.resolveAOEDamageAbility(_name, user, false, 
                 new List<Die>(){ DiceBag.get(8) }, user.Stats().Power, 0, battle);
        }

        public int EnergyCost()
        {
            return _cost;
        }
    }

    public class TauntAbility : Ability
    {
        private static readonly string _name = "Taunt";
        private static readonly int _cost = 2;
        public string Name()
        {
            return _name;
        }

        public void Execute(BattleFighter user, Battle battle)
        {
            user.Taunt = true;
            Console.WriteLine("{0} uses Taunt!", user.Name);
            BattleConsoleUI.printBlockLine();
        }

        public int EnergyCost()
        {
            return _cost;
        }
    }
}