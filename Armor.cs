using System.Threading;

namespace ClassCharacter
{
    class Armor : Spell
    {
        private uint _time;
        private Character _a;
        public Armor(bool verbal_component, bool motor_component) : base(0, verbal_component, motor_component) {}
        public override void To_perform_a_magical_effect(Character a, Character_With_Magic b, uint time)
        {
            _a = a;
            _time = time;
            if (!Check_Component(b, Get_Motor_Component(), Get_Verbal_Component()))
            {
                if (!Check_Dead2(a))
                {
                    if (b.Get_Mana_Now() - time * 50 >= 0)
                    {
                        b.Set_Mana_Now(b.Get_Mana_Now() - time * 50);
                    }
                    else
                    {
                        time = b.Get_Mana_Now() / 50;
                        b.Set_Mana_Now(b.Get_Mana_Now() - time * 50);
                    }
                    Thread t1 = new Thread(Do);
                    t1.Start(this);
                }
            }
        }
        private void Do(object a)
        {
            uint temp = (a as Armor)._a.Get_Health_now();
            for (int i = 0; i < (a as Armor)._time; ++i)
            {
                Thread.Sleep(1000);
                (a as Armor)._a.Set_Health_now((a as Armor)._a.Get_Health_max());
            }
            (a as Armor)._a.Set_Health_now(temp);
        }
    }
}
