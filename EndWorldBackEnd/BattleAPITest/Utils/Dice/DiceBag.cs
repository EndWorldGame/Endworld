using System.Collections.Generic;

namespace MessingAroun.Utils.Dice
{
    public class DiceBag
    {
        private static Dictionary<int, Die> _dictDict = new Dictionary<int, Die>()
        {
            {2, new Die(2)},
            {3, new Die(3)},
            {4, new Die(4)},
            {6, new Die(6)},
            {8, new Die(8)},
            {10, new Die(10)},
            {12, new Die(12)},
            {20, new Die(20)}
        };

        public static Die get(int dieNumber)
        {
            return _dictDict[dieNumber];
        }
    }
}