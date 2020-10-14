namespace CombatTest.Combat
{
    public class Armor
    {
        private string _name = "Unarmored";
        private int _physicalResistance;
        private int _energyResistance;
        StatBlock _statBonus = new StatBlock(0,0,0,0,0);

        public Armor(int physicalResistance, int energyResistance)
        {
            _physicalResistance = physicalResistance;
            _energyResistance = energyResistance;
        }

        public Armor(string name, int physicalResistance, int energyResistance)
        {
            _name = name;
            _physicalResistance = physicalResistance;
            _energyResistance = energyResistance;
        }

        public StatBlock StatBonus
        {
            get => _statBonus;
            set => _statBonus = value;
        }

        public int PowerLevel()
        {
            return _energyResistance + _physicalResistance;
        }

        public int PhysicalResistance
        {
            get => _physicalResistance;
            set => _physicalResistance = value;
        }

        public int EnergyResistance
        {
            get => _energyResistance;
            set => _energyResistance = value;
        }
    }
}