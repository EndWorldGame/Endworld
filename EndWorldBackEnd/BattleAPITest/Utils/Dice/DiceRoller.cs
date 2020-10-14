using System;
using System.Collections.Generic;

namespace MessingAroun.Utils.Dice
{
    class DiceRoller
    {
        private List<Die> _dice = new List<Die>();
        private Random randomizer = new Random();

        public void addDice(Die die)
        {
            _dice.Add(die);
        }

        public void addDice(List<Die> dice)
        {
            foreach (Die die in dice)
            {
                _dice.Add(die);
            }
        }

        public List<Die> Dice
        {
            get { return _dice; }
            set { _dice = value; }
        }

        public int rollDice()
        {
            int total = 0;
            foreach (Die die in _dice)
            {
                total += randomizer.Next(1, die.Sides + 1);
            }

            return total;
        }
    }
}