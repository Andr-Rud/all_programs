
namespace ClassCharacter
{
    class Living_Water_Bottle: Artefact
    {
        public Living_Water_Bottle(Bottles k) : base(0, false) {
            Set_Artefact_power(Bottle(k));
        }
        public override void To_perform_a_magical_effect( Character a, Character_With_Magic b, uint impact_force) {
            if (!Check_Dead(a))
            {
                a.Set_Health_now(a.Get_Health_now() + Get_Artefact_power());
            }
        }
        public uint Bottle(Bottles bottles)
        {
            switch (bottles)
            {
                case Bottles.BIG:
                    return 50;
                case Bottles.MEDIUM:
                    return 25;
                case Bottles.SMALL:
                    return 10;
            }
            return 0;
        }
    }
}
