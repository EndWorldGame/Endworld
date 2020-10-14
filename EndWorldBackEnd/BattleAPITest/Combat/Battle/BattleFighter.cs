using System.Collections.Generic;
using System.Linq;

namespace CombatTest.Combat
{
    public class BattleFighter : Fighter
    {
        private bool _playerChar;
        private int _currentHealth;
        private bool _taunt;
        private StatBlock _statBonus = new StatBlock(0, 0, 0, 0, 0);
        
        public BattleFighter(string name, string type, Weapon weapon, Armor armor, StatBlock stats, bool playerChar) 
            : base(name, type, weapon, armor, stats)
        {
            _currentHealth = stats.Health;
            _playerChar = playerChar;
        }
        
        public BattleFighter(string name, string type, Weapon weapon, Armor armor, StatBlock stats, bool playerChar, int currentHealth) 
            : base(name, type, weapon, armor, stats)
        {
            _currentHealth = currentHealth;
            _playerChar = playerChar;
        }

        public BattleFighter(Fighter fighter, bool playerChar) : base( fighter.Name, fighter.Type, fighter.Weapon,
            fighter.Armor, fighter.ProtoStats, fighter.BaseStats, fighter.ProtoAbilities)
        {
            _currentHealth = fighter.CurrentHealth;
            _playerChar = playerChar;
        }
        
        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        public bool PlayerChar
        {
            get => _playerChar;
            set => _playerChar = value;
        }

        public bool Taunt
        {
            get => _taunt;
            set => _taunt = value;
        }

        private StatBlock getTokenBlock()
        {
            return new StatBlock(new List<StatBlock>(){ Stats(), _statBonus});
        }

        public StatBlock BattleStats()
        {
            return new StatBlock(new List<StatBlock>(){ Stats(), _statBonus});
        }
    }
}