using System;

namespace ClassCharacter
{
    abstract class Spell: IMagic
    {
        private int _mana_min;
        private bool _verbal_component;
        private bool _motor_component;
       public Spell(int mana_min, bool verbal_component, bool motor_component)
        {
            _mana_min = mana_min;
            _verbal_component = verbal_component;
            _motor_component = motor_component;
        }
        public int Get_Mana_Min()
        {
            return _mana_min;
        }
        public bool Get_Verbal_Component()
        {
            return _verbal_component;
        }
        public bool Get_Motor_Component()
        {
            return _motor_component;
        }
        public void Set_Mana_Min(int mana_min)
        {
            _mana_min = mana_min;
        }
        public void Set_Verbal_Component(bool verbal_component)
        {
            _verbal_component = verbal_component;
        }
        public void Set_Motor_Component(bool motor_component)
        {
            _motor_component = motor_component;
        }
        protected bool Check_Component(Character_With_Magic a, bool motor_component, bool verbal_component)
        {
            if ((a.Get_Condition() == Character.Condition.PARALYZED) && (motor_component == true))
            {
                Console.WriteLine($"Заклинание не может быть произнесено. {a.Get_Name()} парализован.");
                return true;
            }
            if (a.Get_Ability_to_speak() == false && verbal_component == true)
            {
                Console.WriteLine($"Заклинание не может быть произнесено. {a.Get_Name()} не может говорить.");
                return true;
            }
            return false;
        }
        protected bool Check_Dead2(Character a)
        {
            if (a.Get_Condition() == Character.Condition.DEAD)
            {
                Console.WriteLine("Заклинание не может быть произнесено. " + a.Get_Name() + " мертв.");
                return true;
            }
            return false;
        }
        protected bool Check_All(Character_With_Magic a, uint mana, Character b, Character.Condition condition)
        {
            if (a.Get_Mana_Now() >= mana)
            {
                if (b.Get_Condition() == condition)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Заклинание не может быть произнесено. " + b.Get_Name() + " " + b.Get_Condition());
                }
            }
            else
            {
                Console.WriteLine("Заклинание не может быть произнесено. У " + a.Get_Name() + " недостаточно маны.");
            }
            return false;
        }
        public abstract void To_perform_a_magical_effect( Character a, Character_With_Magic b, uint impact_force);
    }
}
