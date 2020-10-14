using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using MessingAroun.Utils.Dice;

namespace CombatTest.Combat
{
    public class WeaponDict
    {
        private static Dictionary<string, Weapon> _weaponDict = new Dictionary<string, Weapon>()
        {
            { "Met Blaster", new Weapon("Met Blaster", "Blaster", false, true, 
                new List<Die>(){ DiceBag.get(4) }, 1, 0, 
                new StatBlock(0,0,0,0,0)) },
            { "Monking Fist", new Weapon("Monking Fist", "Fist", true, true, 
                new List<Die>(){ DiceBag.get(8) }, 2, 1, 
                new StatBlock(0,0,1,0,0)) },
            { "Scoped Blast Rifle", new Weapon("Scoped Blast Rifle", "Rifle", false, true, 
                new List<Die>(){ DiceBag.get(6)}, 3, 1, 
                new StatBlock(0,0,0,0,0)) },
            { "Blast Auto-Rifle", new Weapon("Blast Auto-Rifle", "Rifle", false, true, 
                new List<Die>(){ DiceBag.get(3), DiceBag.get(3), DiceBag.get(2) }, 1, 0, 
                new StatBlock(0,0,0,0,0)) },
            { "Crystalline Blaster", new Weapon("Crystalline Blaster", "Blaster", false, true,
                new List<Die>(){ DiceBag.get(6) }, 0, 0, 
                new StatBlock(0,0,0,0,0)) },
            { "Junk Man's Claw", new Weapon("Junk Man's Claw", "Cutter", true, false,
                new List<Die>(){ DiceBag.get(10) }, 2, 1, 
                new StatBlock(0, 0, 0, 0, 0) )},
            { "Frigid Blaster", new Weapon("Frigid Blaster", "Blaster", false, true,
                new List<Die>(){ DiceBag.get(6), new Die(4) }, 2, 1, 
                new StatBlock(0, 0, 0, 0, 1) )},
            { "Flash Blaster", new Weapon("Flash Blaster", "Blaster", false, true,
                new List<Die>(){ DiceBag.get(6) }, 2, 1, 
                new StatBlock(0, 0, 0, 0, 0) )},
            { "Fire Blaster", new Weapon("Fire Blaster", "Blaster", false, true,
                new List<Die>(){ DiceBag.get(6), new Die(4) }, 2, 0, 
                new StatBlock(0, 0, 0, 0, 2) )},
            { "Commando Blaster", new Weapon("Commando Blaster", "Blaster", false, true,
                new List<Die>(){ new Die(8) }, 3, 1, 
                new StatBlock(2, 0, 0, 0, 2) )},
            { "Stone Blaster", new Weapon("Stone Blaster", "Blaster", false, true,
                new List<Die>(){ new Die(8) }, 2, 0, 
                new StatBlock(1, 0, 0, 0, 0) )},
            { "Quick Blaster", new Weapon("Quick Blaster", "Blaster", false, true,
                new List<Die>(){ new Die(6) }, 3, 1, 
                new StatBlock(0, 0, 0, 1, 0) )},
        };

        public static Weapon get(string weaponName)
        {
            return _weaponDict[weaponName].copy();
        }
    }
}