
namespace ClassCharacter
{
    class Add_Health : Spell
    {
        public Add_Health(bool verbal_component, bool motor_component) : base(0, verbal_component, motor_component) { }
        public override void To_perform_a_magical_effect(Character a, Character_With_Magic b, uint increase_by)
        {
            if (!Check_Component(b, Get_Motor_Component(), Get_Verbal_Component()))
            {
                if (!Check_Dead2(a))
                {
                    if (a.Get_Health_now() + increase_by > a.Get_Health_max())
                    {
                        increase_by = a.Get_Health_max() - a.Get_Health_now();
                    }
                    if (increase_by * 2 > b.Get_Mana_Now())
                    {
                        increase_by = b.Get_Mana_Now() / 2;
                    }
                    b.Set_Mana_Now(b.Get_Mana_Now() - increase_by * 2);
                    a.Set_Health_now(a.Get_Health_now() + increase_by);
                }
            }
        }
    }
}
