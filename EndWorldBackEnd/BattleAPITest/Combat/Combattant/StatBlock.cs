using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CombatTest.Combat
{
    public class StatBlock
    {
        private int _id;
        private int _health;
        private int _energy;
        private int _strength;
        private int _speed;
        private int _power;

        public StatBlock(int health, int energy, int strength, int speed, int power)
        {
            _health = health;
            _energy = energy;
            _strength = strength;
            _speed = speed;
            _power = power;
        }
        
        public StatBlock(List<StatBlock> blocks)
        {
            _health = blocks.Sum(block => block.Health);
            _energy = blocks.Sum(block => block.Energy);
            _strength = blocks.Sum(block => block.Strength);
            _speed = blocks.Sum(block => block.Speed);
            _power = blocks.Sum(block => block.Power);
        }

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        public int Energy
        {
            get => _energy;
            set => _energy = value;
        }

        public int Strength
        {
            get => _strength;
            set => _strength = value;
        }

        public int Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public int Power
        {
            get => _power;
            set => _power = value;
        }
    }
}