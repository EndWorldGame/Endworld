using System;
using System.Collections.Generic;
using System.Linq;
using CombatTest.Combat.Action;

namespace CombatTest.Combat
{
    public class Battle
    {
        private List<BattleFighter> _allFighters = new List<BattleFighter>();
        private int _turn = 0;
        private bool _battleContinue = true;
        private static AttackAction _attackAction = new AttackAction();
        private static AbilityAction _abilityAction = new AbilityAction();
        private List<IAction> _actions = new List<IAction>(){ _attackAction, _abilityAction };

        public Battle(Party playerParty, Party enemyParty)
        {
            _allFighters.AddRange(playerParty.getPartyMembers()
                .Select(x => { return new BattleFighter(x, true); }).ToList());
            _allFighters.AddRange(enemyParty.getPartyMembers()
                .Select(x => { return new BattleFighter(x, false); }).ToList());
        }

        public List<BattleFighter> AllFighters
        {
            get => _allFighters;
            set => _allFighters = value;
        }

        private void sortFightersBySpeed()
        {
            this._allFighters = _allFighters.OrderByDescending(x => x.BattleStats().Speed).ToList();
        }

        public void checkForDeadFighters()
        {
            _allFighters.Where(x => x.CurrentHealth == 0).ToList().ForEach(y =>
            {
                Console.WriteLine("{0} has been killed.", y.Name);
                BattleConsoleUI.printBlockLine();
            });
            _allFighters = _allFighters.Where(x => x.CurrentHealth > 0).ToList();
            checkForBattleOver();
        }

        private void checkForBattleOver()
        {
            int _playerPartyCount = _allFighters.Where(x => x.PlayerChar).ToList().Count;
            int _enemyPartyCount = _allFighters.Count - _playerPartyCount;
            if (_playerPartyCount == 0 || _enemyPartyCount == 0)
            {
                _battleContinue = false;
                BattleConsoleUI.printBattleOverMessage(_playerPartyCount > _enemyPartyCount);
            }
        }

        private void resolveTurn(BattleFighter fighter)
        {
            if (fighter.PlayerChar)
            {
                fighter.Taunt = false;
                bool turnLoop = true;
                bool validAction = false;
                int choice = 1;
                while (turnLoop)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    BattleConsoleUI.printFighterTurn(fighter, _turn);
                    BattleConsoleUI.showCombatActions(_actions);
                    validAction = Int32.TryParse(Console.ReadLine(), out choice);
                    choice -= 1;
                    if (validAction)
                    {
                        turnLoop = _actions[choice].Execute(fighter, this);
                    }
                }
            }
            else
            {
                Random randomizer = new Random();
                Console.ForegroundColor = ConsoleColor.Red;
                List<BattleFighter> _partyFighters = _allFighters.Where(x => x.PlayerChar).ToList();
                List<BattleFighter> _tauntingFighters = _allFighters.Where(x => x.Taunt).ToList();
                if (_tauntingFighters.Count > 0)
                {
                    _partyFighters = _tauntingFighters;
                }
                BattleFighter target = _partyFighters[randomizer.Next(_partyFighters.Count)];
                _attackAction.Execute(fighter, target, this);
            }
        }
        
        public void execute()
        {
            sortFightersBySpeed();
            BattleConsoleUI.printFighters(this, _turn);
            while (_battleContinue)
            {
                _turn++;
                foreach (BattleFighter fighter in _allFighters)
                {
                    if (fighter.CurrentHealth > 0)
                    {
                        resolveTurn(fighter);
                        checkForDeadFighters();   
                    }
                    if (!_battleContinue)
                    {
                        break;
                    }
                }

                if (_battleContinue)
                {
                    BattleConsoleUI.printFighters(this, _turn);
                }
            }
        }
    }

    
}