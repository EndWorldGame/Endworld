using System.Collections.Generic;

namespace CombatTest.Combat.Action
{
    public interface IAction
    {
        string Name();
        bool Execute(BattleFighter user, Battle battle);
    }
}