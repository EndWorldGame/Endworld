using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MessingAroun.Utils.Dice;

namespace CombatTest.Combat
{
    public class Weapon
    {
        private string _name;
        private string _type; // Sword, Mace, Spear, Cutter, Blaster, Rifle, Special
        private bool _physical;
        private bool _ranged;
        private List<Die> _damageDice;
        private int _hitBonus;
        private int _damageBonus;
        private StatBlock _statBonus = new StatBlock(0,0,0,0,0);
        //private List<WeaponAttribute> _weaponAttributes;
        //private List<WeaponAbilities> _weaponAbilities

        public Weapon(string name, string type, bool physical, bool ranged, List<Die> damageDice, int hitBonus, 
            int damageBonus, StatBlock statBonus)
        {
            _name = name;
            _type = type;
            _physical = physical;
            _ranged = ranged;
            _damageDice = damageDice;
            _hitBonus = hitBonus;
            _damageBonus = damageBonus;
            _statBonus = statBonus;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Type
        {
            get => _type;
            set => _type = value;
        }

        public bool Physical
        {
            get => _physical;
            set => _physical = value;
        }

        public bool Ranged
        {
            get => _ranged;
            set => _ranged = value;
        }

        public List<Die> DamageDice
        {
            get => _damageDice;
            set => _damageDice = value;
        }
        
        public int HitBonus
        {
            get => _hitBonus;
            set => _hitBonus = value;
        }

        public int DamageBonus
        {
            get => _damageBonus;
            set => _damageBonus = value;
        }

        public StatBlock StatBonus
        {
            get => _statBonus;
            set => _statBonus = value;
        }

        public int AverageDamage()
        {
            int total = 0;
            foreach (Die die in DamageDice)
            {
                total += (die.Sides + 1) / 2;
            }

            return total + _damageBonus;
        }

        public int PowerLevel()
        {
            return AverageDamage() + HitBonus;
        }
        

        public Weapon copy()
        {
            return (Weapon)this.MemberwiseClone();
        }
    }
    
}