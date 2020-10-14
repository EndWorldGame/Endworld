using System;
using System.Collections.Generic;
using System.Linq;
using MessingAroun.Utils.Dice;

namespace CombatTest.Combat
{
    public class FighterDict
    {
        private static readonly string NORMAL_TYPE = "Normal";
        private static readonly string NATURE_TYPE = "Nature";
        private static string ICE_TYPE = "Ice";
        private static string METAL_TYPE = "Metal";
        private static string FIRE_TYPE = "Fire";
        private static string BIO_TYPE = "Bio";
        private static string SPACE_TYPE = "Space";
        private static string GROUND_TYPE = "Ground";

        private static Dictionary<string, Fighter> combattantDict = new Dictionary<string, Fighter>()
        {
            {
                "Metall", 
                new Fighter("Metall", NORMAL_TYPE,
                    WeaponDict.get("Met Blaster"), 
                    new Armor("Met Armor Core I", 1,0), 
                    new StatBlock(10, 2, 0, 0, 0))
            },
            {
                "Monking", 
                new Fighter("Monking", NATURE_TYPE,
                    WeaponDict.get("Monking Fist"), 
                    new Armor("Monking Armor Core I", 3,2), 
                    new StatBlock(20, 2, 3, 0, 0))
            },
            {
                "Sniper Joe", 
                new Fighter("Sniper Joe", NORMAL_TYPE,
                    WeaponDict.get("Scoped Blast Rifle"), 
                    new Armor("Sniper Joe Armor Core I", 2,1), 
                    new StatBlock(18, 5, 0, 1, 0),
                    new List<Ability>(){ new SnipeAbility() })
            },
            {
                "Machine Gun Joe", 
                new Fighter("Machine Gun Joe", NORMAL_TYPE,
                    WeaponDict.get("Blast Auto-Rifle"), 
                    new Armor("Sniper Joe Armor Core I", 2,1), 
                    new StatBlock(18, 5, 0, 1, 0),
                    new List<Ability>(){ new RapidFireAbility() })
            },
            {
                "Junk Man", 
                new Fighter("Junk Man", METAL_TYPE,
                    WeaponDict.get("Junk Man's Claw"), 
                    new Armor("Junk Man's Armor Core I", 5,4), 
                    new StatBlock(36, 10, 4, 0, 0))
            },
            {
                "Freeze Man", 
                new Fighter("Freeze Man", ICE_TYPE,
                    WeaponDict.get("Frigid Blaster"), 
                    new Armor("Freeze Man's Armor Core I", 2,3), 
                    new StatBlock(30, 10, 0, 2, 3), 
                    new List<Ability>(){ new IceBeamAbility() })
            },
            {
                "Fire Man", 
                new Fighter("Fire Man", FIRE_TYPE,
                    WeaponDict.get("Fire Blaster"), 
                    new Armor("Fire Man's Armor Core I", 3,1), 
                    new StatBlock(30, 10, 1, 1, 2), 
                    new List<Ability>(){ new FireStormAbility(), new FireBlastAbility() })
            },
            {
                "Flash Man",
                new Fighter("Flash Man", SPACE_TYPE,
                    WeaponDict.get("Flash Blaster"), 
                    new Armor("Flash Man's Armor Core I", 1,3), 
                  new StatBlock(28, 10, 0, 2, 2), 
                  new List<Ability>(){ new FlashbackAbility(), new DoubleFlashbackAbility() })
            },
            {
                "Quick Man", 
                new Fighter("Quick Man", NORMAL_TYPE,
                    WeaponDict.get("Quick Blaster"), 
                    new Armor("Quick Man's Armor Core I", 2,1), 
                    new StatBlock(27, 10, 0, 4, 0), 
                    new List<Ability>(){ new QuickBoomerangAbility() })
            },
            {
                "Commando Man", 
                new Fighter("Commando Man", NORMAL_TYPE,
                    WeaponDict.get("Commando Blaster"), 
                    new Armor("Commando Man's Armor Core I", 2,2), 
                    new StatBlock(32, 10, 2, 0, 3), 
                    new List<Ability>(){ new RapidFireAbility(), new SnipeAbility(), new CommandoBombAbility() })
            },
            {
                "Stone Man", 
                new Fighter("Stone Man", GROUND_TYPE,
                    WeaponDict.get("Stone Blaster"), 
                    new Armor("Stone Man's Armor Core I", 5,5), 
                    new StatBlock(36, 8, 4, 0, 0), 
                    new List<Ability>(){ new TauntAbility() })
            },
            {
                "Alien", 
                new Fighter("Alien", BIO_TYPE,
                    WeaponDict.get("Scoped Blast Rifle"), 
                    new Armor("Alien Carapace", 3,3), 
                    new StatBlock(31, 10, 2, 2, 2), 
                    new List<Ability>(){ new IceBeamAbility(), new TriBeamAbility(), new FireBlastAbility() })
            }
        };

        public static Fighter get(string combattantName)
        {
            return combattantDict[combattantName];
        }

        public static List<Fighter> get(List<string> combattantNames)
        {
            return combattantNames.Select(x => { return get(x); }).ToList();
        }
    }
}