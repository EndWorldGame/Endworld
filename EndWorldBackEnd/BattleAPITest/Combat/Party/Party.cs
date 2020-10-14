using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CombatTest.Combat
{
    public class Party
    {
        private List<Fighter> _members = new List<Fighter>();
        private string _partyName;

        public Party()
        {
            
        }

        public Party(List<string> fighterNames)
        {
            add(fighterNames);
        }

        public Party(List<Fighter> fighters)
        {
            this._members.AddRange(fighters);
        }

        public Party(Fighter fighter)
        {
            this._members.Add(fighter);
        }

        public void add(Fighter fighter)
        {
            this._members.Add(fighter);
            //Cant add with same name, rename one of them option.
        }

        public void add(List<Fighter> fighters)
        {
            this._members.AddRange(fighters);
        }

        public void add(List<string> fighterNames)
        {
            this._members.AddRange(fighterNames.Select(x => { return FighterDict.get(x); }).ToList());
        }

        public void remove()
        {
            
        }

        public void get()
        {
            
        }

        public List<Fighter> getPartyMembers()
        {
            return this._members;
        }
    }
}