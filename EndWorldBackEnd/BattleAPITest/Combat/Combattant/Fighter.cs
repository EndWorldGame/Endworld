using System.Collections.Generic;
using System.Linq;

namespace CombatTest.Combat
{
    public class Fighter
    {
        private string _name;
        private string _type;
        private Weapon _weapon;
        private Armor _armor;
        private readonly StatBlock _protoStats;
        private StatBlock _baseStats;
        private int _currentHealth;
        private int _currentEnergy;
        private List<Ability> _protoAbilities = new List<Ability>();
        
        public Fighter(string name, string type, Weapon weapon, Armor armor, StatBlock protoStats)
        {
            _name = name;
            _type = type;
            _weapon = weapon;
            _armor = armor;
            _protoStats = protoStats;
            _baseStats = protoStats;
            _currentHealth = protoStats.Health;
            _currentEnergy = protoStats.Energy;
        }
        
        public Fighter(string name, string type, Weapon weapon, Armor armor, StatBlock protoStats, List<Ability> protoAbilities)
        {
            _name = name;
            _type = type;
            _weapon = weapon;
            _armor = armor;
            _protoStats = protoStats;
            _baseStats = protoStats;
            _currentHealth = protoStats.Health;
            _currentEnergy = protoStats.Energy;
            _protoAbilities.AddRange(protoAbilities);
        }
        
        public Fighter(string name, string type, Weapon weapon, Armor armor, StatBlock protoStats, StatBlock baseStats, List<Ability> protoAbilities)
        {
            _name = name;
            _type = type;
            _weapon = weapon;
            _armor = armor;
            _protoStats = protoStats;
            _baseStats = baseStats;
            _currentHealth = protoStats.Health;
            _currentEnergy = protoStats.Energy;
            _protoAbilities = protoAbilities;
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
        
        public Weapon Weapon
        {
            get => _weapon;
            set => _weapon = value;
        }

        public Armor Armor
        {
            get => _armor;
            set => _armor = value;
        }

        public StatBlock ProtoStats => _protoStats;

        public StatBlock BaseStats
        {
            get => _baseStats;
            set => _baseStats = value;
        }

        public List<Ability> ProtoAbilities
        {
            get => _protoAbilities;
            set => _protoAbilities = value;
        }

        public StatBlock Stats()
        {
            return new StatBlock(new List<StatBlock>(){ BaseStats, Weapon.StatBonus, Armor.StatBonus });
        }

        public int PowerLevel()
        {
            return _weapon.PowerLevel() + _armor.PowerLevel() + (Stats().Energy / 2) + (Stats().Health / 3) +
                   Stats().Strength + Stats().Speed + Stats().Power;
        }

        public List<Ability> GetAbilities()
        {
            return _protoAbilities;
        } 

        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        public int CurrentEnergy
        {
            get => _currentEnergy;
            set => _currentEnergy = value;
        }

        public Fighter copy()
        {
            Fighter clone = (Fighter)this.MemberwiseClone();
            clone._protoAbilities.AddRange(_protoAbilities);
            return clone;
        }
        
    }
}