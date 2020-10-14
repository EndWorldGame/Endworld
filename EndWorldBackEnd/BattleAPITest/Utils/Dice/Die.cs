namespace MessingAroun.Utils.Dice
{
    public class Die
    {
        private int _sides;
        public Die(int sides)
        {
            _sides = sides;
        }

        public int Sides
        {
            get { return _sides; }
            set { _sides = value; }
        }
    }
}