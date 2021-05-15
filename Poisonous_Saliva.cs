using System;
using System.Threading;

namespace ClassCharacter
{
    class Poisonous_Saliva : Artefact
    {
        public Poisonous_Saliva (uint artefact_power_now) : base(artefact_power_now, true) {
        }
        public override void To_perform_a_magical_effect( Character a, Character_With_Magic b, uint artefact_power)
        {
            if (!Check_Dead(a))
            {
                a.Set_Condition(Character.Condition.POISONED);
            }
            Thread t = new Thread(Do);
            t.Start(a);
        }
        private void Do(object a)
        {
            while ((a as Character).Get_Condition() == Character.Condition.POISONED)
            {
                Thread.Sleep(1000);
                if ((a as Character).Get_Health_now() - Get_Artefact_power() > 0)
                {
                    (a as Character).Set_Health_now((a as Character).Get_Health_now() - Get_Artefact_power());
                }
                else
                {
                    (a as Character).Set_Health_now(0);
                }
                if ((a as Character).Get_Health_now() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Персонаж " + (a as Character).Get_Name() + " умер от отравления.");
                    Console.ResetColor();
                    break;
                }
            }
        }
    }
}
