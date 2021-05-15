using System;
using System.Collections.Generic;

namespace ClassCharacter
{
    class Character
    {
        private static int _next_index = 0;
        private int _index;
        private string _name;
        private Condition _condition;
        private Race _raсe;
        private bool _ability_to_speak;
        private bool _ability_to_move;
        private Gender _gender;
        private uint _age;
        private uint _health_max;
        private uint _health_now;
        private uint _experience;
        private List<Artefact> _inventory;
        public Character(string name, Condition condition, Race race, bool ability_to_speak, bool ability_to_move, Gender gender, uint age, uint health_max, uint health_now, uint experience)
        {

            ++_next_index;
            _index = _next_index;
            _name = name;
            Set_Race(race);
            Set_Ability_to_speak(ability_to_speak);
            Set_Ability_to_move(ability_to_move);
            Set_Gender(gender);
            Set_Age(age);
            Set_Health_max(health_max);
            Set_Health_now(health_now);
            Set_Experience(experience);
            _inventory = new List<Artefact>();
            Set_Condition(condition);
            Check_Condition();
        }
        public Character()
        {
            ++_next_index;
            _index = _next_index;
            _name = "Unknown";
            Set_Condition(Condition.NORMAL);
            Set_Race(Race.PERSON);
            Set_Ability_to_speak(true);
            Set_Ability_to_move(true);
            Set_Gender(Gender.FEMALE);
            Set_Age(30);
            Set_Health_max(100);
            Set_Health_now(100);
            Set_Experience(0);
            _inventory = new List<Artefact>();
        }
        public int Get_Index()
        {
            return _index;
        }
        public string Get_Name()
        {
            return _name;
        }
        public Condition Get_Condition()
        {
            return _condition;
        }
        public Race Get_Raсe()
        {
            return _raсe;
        }
        public bool Get_Ability_to_speak()
        {
            return _ability_to_speak;
        }
        public void Set_Ability_to_speak(bool ability_to_speak)
        {
            _ability_to_speak = ability_to_speak;
        }
        public bool Get_Ability_to_move()
        {
            return _ability_to_move;
        }
        public void Set_Ability_to_move(bool ability_to_move)
        {
            _ability_to_move = ability_to_move;
        }
        public Gender Get_Gender()
        {
            return _gender;
        }
        public uint Get_Age()
        {
            return _age;
        }
        public void Set_Age(uint age)
        {
            _age = age;
        }
        public uint Get_Health_max()
        {
            return _health_max;
        }
        public void Set_Health_max(uint health_max)
        {
            if (health_max < this.Get_Health_now())
            {
                _health_now = health_max;
            }
            _health_max = health_max;
        }
        public uint Get_Health_now()
        {
            return _health_now;
        }
        public void Set_Health_now(uint health_now)
        {
            if (health_now > Get_Health_max())
            {
                _health_now = _health_max;
            }
            _health_now = health_now;
            Check_Condition();
        }
        public uint Get_Experience()
        {
            return _experience;
        }
        public void Set_Experience(uint experience)
        {
            _experience = experience;
        }
        public enum Condition
        {
            NORMAL,
            WEAKENED,
            SICK,
            POISONED,
            PARALYZED,
            DEAD
        };
        public void Set_Condition(Condition condition)
        {
            _condition = condition;
            if (condition == Condition.PARALYZED)
            {
                Set_Ability_to_move(false);
            }
            if (condition == Condition.DEAD)
            {
                Set_Ability_to_move(false);
                Set_Ability_to_speak(false);
            }
            Check_Condition();
        }
        public enum Race
        {
            PERSON,
            GNOME,
            ELF,
            ORC,
            GOBLIN
        };
        private void Set_Race(Race race)
        {
            _raсe = race;
        }
        public enum Gender
        {
            MALE,
            FEMALE
        };
        private void Set_Gender(Gender gender)
        {
            _gender = gender;
        }
        public virtual new string ToString()
        {
           // Console.ForegroundColor = ConsoleColor.Green;
            return "***********************" +
                '\n' + " id: " + _index + '\n' + " name: " + _name + '\n' + " condition: " + _condition + '\n' +
                " race: " + _raсe + '\n' + " ability to speak: " + _ability_to_speak + '\n' +
                " ability to move: " + _ability_to_move + '\n' + " gender: " + _gender + '\n' + " age: " + _age + '\n' + " health_max: " +
                _health_max + '\n' + " health now: " + _health_now + '\n' + " experience: " + _experience + '\n';
        }
        private void Check_Condition()
        {
            if ((Get_Health_now() > 0) && (Get_Condition() == Condition.DEAD))
            {
                Set_Condition(Condition.NORMAL);
            }
            if ((Get_Condition() == Condition.NORMAL) && (Convert.ToDouble(Get_Health_now()) / Convert.ToDouble(Get_Health_max()) < 0.1))
            {
                Set_Condition(Condition.SICK);
            }
            if ((Get_Condition() == Condition.SICK) && (Convert.ToDouble(Convert.ToDouble(Get_Health_now()) / Convert.ToDouble(Get_Health_max())) >= 0.1))
            {
                Set_Condition(Condition.NORMAL);
            }
            if (Get_Health_now() == 0)
            {
                Set_Condition(Condition.DEAD);
            }
        }
        protected bool Check_Dead()
        {
            if (Get_Condition() == Condition.DEAD)
            {
                Console.WriteLine("Действие недоступно. Персонаж " + Get_Name() + " мертв");
                return true;
            }
            return false;
        }
        private bool Check_Paralyzed()
        {
            if (Get_Condition() == Condition.PARALYZED)
            {
                Console.WriteLine("Действие недоступно. Персонаж " + Get_Name() + " парализован");
                return true;
            }
            return false;
        }
        public string Comparison_by_experience(Character a, Character b)
        {
            if (a.Get_Experience() > b.Get_Experience())
            {
                return "exp " + a.Get_Name() + " with id " + a.Get_Index() + " > exp " + b.Get_Name() + " with id " + b.Get_Index();
            }
            if (a.Get_Experience() < b.Get_Experience())
            {
                return "exp " + a.Get_Name() + " with id " + a.Get_Index() + " < exp " + b.Get_Name() + " with id " + b.Get_Index();
            }
            else
            {
                return "exp " + a.Get_Name() + " with id " + a.Get_Index() + " == exp " + b.Get_Name() + " with id " + b.Get_Index();
            }
        }
        public void Pick_Up_An_Artefact(Artefact a)
        {
            if (!Check_Dead() && (!Check_Paralyzed())) {
                _inventory.Add(a);
            }
        }
        public void Throw_Away_The_Artefact(Artefact a)
        {
            if (!Check_Dead() && !Check_Paralyzed())
            {
                if (!_inventory.Remove(a))
                {
                    Console.WriteLine(this.Get_Name() + " не может выбросить артефакт, т.к. его у него не было.");
                }
            }
        }
        public void Transfer_An_Artefact_To_Another_Character(Artefact a, Character b)
        {
            Throw_Away_The_Artefact(a);
            b.Pick_Up_An_Artefact(a);
        }
        private bool Check_Use(Artefact a)
        {
            if (((a.GetType().Name == "Living_Water_Bottle") || (a.GetType().Name == "Dead_Water_Bottle") ||
                (a.GetType().Name == "Frog_Legs_Decort") || (a.GetType().Name == "Basilisk_Eye")) && (!_inventory.Remove(a)))
            {
                return false;
            }
            if (((a.GetType().Name == "Staff_Lightning") || (a.GetType().Name == "Poisonous_Saliva")) && (_inventory.IndexOf(a) < 0))
            {
                return false;
            }
            return true;
        }
        public void Use_Artefact(Artefact a, Character b, uint power)
        {
            if (a is Dead_Water_Bottle)
            {
                if (!Check_Dead() && !Check_Paralyzed())
                {
                    if (Check_Use(a))
                    {
                        Character temp = new Character();
                        a.To_perform_a_magical_effect(temp, (b as Character_With_Magic), power);
                    }
                    else
                    {
                        Console.WriteLine(Get_Name() + " не может использовать артефакт, т.к. его у него нет.");
                    }
                }
            }
            else
            {
                if (!Check_Dead() && !Check_Paralyzed())
                {
                    if (Check_Use(a))
                    {
                        Character_With_Magic temp = new Character_With_Magic();
                        a.To_perform_a_magical_effect(b, temp, power);
                    }
                    else
                    {
                        Console.WriteLine(Get_Name() + " не может использовать артефакт, т.к. его у него нет.");
                    }
                }
            }
        }
        public void Use_Artefact(Artefact a, Character b)
        {
            Use_Artefact(a, b, 1);
        }
        public void Hit(Character a, uint power)
        {
            if (a.Get_Health_now() > power)
            {
                a.Set_Health_now(a.Get_Health_now() - power);
            }
            else
            {
                a.Set_Health_now(0);
                a.Set_Condition(Condition.DEAD);
            }
        }
        public string Inventory_To_String()
        {
            if (_inventory.Count == 0)
            {
                return "Inventory is empty";
            }
            string s = "...................................." + '\n';
            foreach(Artefact i in _inventory)
            {
                s += i.GetType().Name + '\n';
            }
            return s + "...................................." + '\n';
        }
    }
}