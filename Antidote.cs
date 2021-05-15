
namespace ClassCharacter
{
    class Antidote : Spell
    {
        public Antidote(bool verbal_component, bool motor_component) : base(30, verbal_component, motor_component) { }
        public override void To_perform_a_magical_effect(Character a, Character_With_Magic b, uint k)
        {
            if (!Check_Component(b, Get_Motor_Component(), Get_Verbal_Component()))
            {
                if (Check_All(b, 30, a, Character.Condition.POISONED))
                {
                    if (b.Get_Mana_Now() >= 30 && a.Get_Condition() == Character.Condition.POISONED)
                    {
                        a.Set_Condition(Character.Condition.WEAKENED);
                        b.Set_Mana_Now(b.Get_Mana_Now() - 30);
                    }
                }
            }
        }
    }
}
