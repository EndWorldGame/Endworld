using System;
using System.Collections.Generic;
using System.Linq;
using CombatTest.Combat;

namespace CombatTest
{

    class Program
    {
        static void Main(string[] args)
        {
            Battle battle = new Battle(
                new Party(new List<string>(){"Alien", "Flash Man", "Fire Man", "Commando Man"}), 
                new Party(new List<string>(){"Freeze Man", "Junk Man", "Quick Man", "Commando Man" })
                );
            battle.execute();
        }
    }
}