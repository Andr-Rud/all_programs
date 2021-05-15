using System;
using System.Collections.Generic;
namespace ClassCharacter
{
    class Character_With_Magic : Character
    {
        private uint _mana_now;
        private uint _mana_max;
        private List<Spell> _knowledge;
        public Character_With_Magic(string name, Condition condition, Race race, bool ability_to_speak, bool ability_to_move, Gender gender, uint age, uint health_max, uint health_now, uint experience, uint mana_max, uint mana_now)
            : base(name, condition, race, ability_to_speak, ability_to_move, gender, age, health_max, health_now, experience)
        {
            Set_Mana_Max(mana_max);
            Set_Mana_Now(mana_now);
            _knowledge = new List<Spell>();
        }
        public Character_With_Magic():base("Unknown", Condition.NORMAL, Race.PERSON, true, true, Gender.MALE, 100, 100, 100, 0)
        {
            Set_Mana_Max(100);
            Set_Mana_Now(100);
            _knowledge = new List<Spell>();
        }
        public void Set_Mana_Max(uint mana_max)
        {
            if (mana_max < Get_Mana_Now())
            {
                _mana_now = mana_max;
            }
            _mana_max = mana_max;
        }
        public void Set_Mana_Now(uint mana_now)
        {
            if (mana_now > Get_Mana_Max())
            {
                _mana_now = this.Get_Mana_Max();
            }
            _mana_now = mana_now;
        }
        public uint Get_Mana_Max()
        {
            return _mana_max;
        }
        public uint Get_Mana_Now()
        {
            return _mana_now;
        }
        public override string ToString()
        {
            return base.ToString() + " mana_max: " + _mana_max + '\n' + " mana_now: " + _mana_now + '\n';
        }
        public void Tell(Spell a, Character b, uint k)
        {
            if ((_knowledge.IndexOf(a) >= 0) && (!Check_Dead())){
                a.To_perform_a_magical_effect(b, this, k);
            }
        }
        public void Tell(Spell a, Character b)
        {
            Tell(a, b, 1);
        }
        public void Learn(Spell a){
            if (!Check_Dead())
            {
                _knowledge.Add(a);
            }
        }
        public void Forget(Spell a)
        {
            if (!Check_Dead())
            {
                if (!_knowledge.Remove(a))
                {
                    Console.WriteLine(Get_Name() + " не может забыть заклинание, т.к. он его не знал.");
                }
            }
        }
    }
}
