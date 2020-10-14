using System.Collections.Generic;

namespace CombatTest.Combat
{
    public interface Ability
    {
        string Name();
        void Execute(BattleFighter user, Battle battle);
        int EnergyCost();
    }
}