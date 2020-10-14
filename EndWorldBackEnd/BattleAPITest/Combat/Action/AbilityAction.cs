using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace CombatTest.Combat.Action
{
    public class AbilityAction : IAction
    {
        public string Name()
        {
            return "Abilities";
        }

        public bool Execute(BattleFighter user, Battle battle)
        {
            bool validInput = false;
            int choice = 1;
            while (!validInput)
            {
                int _enumerator = 1;
                user.GetAbilities().ForEach(x =>
                {
                    Console.WriteLine("{0}. {1} [{2}]", _enumerator, x.Name(), x.EnergyCost());
                    _enumerator++;
                });
                Console.WriteLine("{0}. {1}", user.GetAbilities().Count+1, "Cancel");
                validInput = (Int32.TryParse(Console.ReadLine(), out choice) && (choice > 0 && choice < user.GetAbilities().Count+2));
                BattleConsoleUI.printBlockLine();
                if (!validInput)
                {
                    Console.WriteLine("Invalid choice, please choose a number between 1 and {0}", _enumerator);
                }
            }
            
            choice -= 1;
            if (choice == user.GetAbilities().Count)
            {
                return true;
            }

            Ability chosenAbility = user.GetAbilities()[choice];

            if (chosenAbility.EnergyCost() > user.CurrentEnergy)
            {
                Console.WriteLine("You need {0} energy to use that ability.", chosenAbility.EnergyCost());
                BattleConsoleUI.printBlockLine();
                return true;
            }
            
            chosenAbility.Execute(user, battle);
            user.CurrentEnergy -= chosenAbility.EnergyCost();
            return false;
        }
    }
}