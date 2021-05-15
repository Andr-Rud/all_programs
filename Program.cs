using System;
using System.Threading;

namespace ClassCharacter
{
    class Program
    {
        static void History1()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                   History 1" + '\n');
            Console.ResetColor();
            Thread.Sleep(1000);

            Character dark_knight = new Character("dark knight", Character.Condition.NORMAL, Character.Race.PERSON, false, true, Character.Gender.MALE, 40, 100, 100, 70);
            Character_With_Magic joker = new Character_With_Magic("joker", Character_With_Magic.Condition.NORMAL, Character_With_Magic.Race.ELF, true, true, Character_With_Magic.Gender.MALE, 29, 80, 80, 20, 300, 300);
            Character_With_Magic old_hermit = new Character_With_Magic("old hermit", Character_With_Magic.Condition.NORMAL, Character_With_Magic.Race.GOBLIN, true, true, Character_With_Magic.Gender.MALE, 50, 100, 90, 150, 400, 400);

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine(dark_knight.ToString());
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine(joker.ToString());
            //Console.ForegroundColor = ConsoleColor.DarkMagenta;
            //Console.WriteLine(old_hermit.ToString());
            //Console.ResetColor();

            /* Действующие лица */

            //Thread.Sleep(2000);

            Staff_Lightning emerald_staff = new Staff_Lightning(20, 20);
            Add_Health heal = new Add_Health(true, true);
            Basilisk_Eye b_eye = new Basilisk_Eye();

            joker.Pick_Up_An_Artefact(emerald_staff);
            old_hermit.Pick_Up_An_Artefact(b_eye);
            old_hermit.Learn(heal);
            Console.WriteLine($"Давным-давно в далекой стране мирно жили герои... Но все изменилось, когда {joker.Get_Name()} решил захватить королевство. Он шел по дороге и увидел {dark_knight.Get_Name()}..." + '\n');
            Console.WriteLine($"Злой {joker.Get_Name()} собирается поразить рыцаря изумрудным посохом (введите силу заряда)");
            int hp = Convert.ToInt32(Console.ReadLine());
            while (hp <= 0)
            {
                Console.WriteLine("Сила должна быть больше 0! Введите еще раз.");
                hp = Convert.ToInt32(Console.ReadLine());
            }
            joker.Use_Artefact(emerald_staff,dark_knight, (uint)hp);

            Console.WriteLine($"И у {dark_knight.Get_Name()} осталось {dark_knight.Get_Health_now()} hp");
            uint old_health = dark_knight.Get_Health_now();
            old_hermit.Tell(heal, dark_knight, 20);
            Console.WriteLine($"Но {old_hermit.Get_Name()} был рядом и исцелил {dark_knight.Get_Name()} на {dark_knight.Get_Health_now() - old_health } hp");
            Console.WriteLine($"Итак, {joker.Get_Name()} собирается зарядить свой посох...");

           // Thread.Sleep(4000);
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Заряд посоха: {emerald_staff.Get_Artefact_power()}");
                if (emerald_staff.Get_Artefact_power() == emerald_staff.Get_Artefact_Power_Max())
                {
                    Console.WriteLine("Посох заряжен!");
                    break;
                }
            }
            Console.ResetColor();
            Console.WriteLine($"... Но это заметил {old_hermit.Get_Name()} и парализовал {joker.Get_Name()} глазом василиска, который завалялся у него в кармане.");
            old_hermit.Use_Artefact(b_eye, joker);
            Console.WriteLine($"А потом {old_hermit.Get_Name()} и {dark_knight.Get_Name()} связали {joker.Get_Name()} и оставили в лесу .........");

        }
        static void History2()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                   History 2" + '\n');
            Console.ResetColor();
            Thread.Sleep(3000);
            Character worker_John = new Character("worker John", Character.Condition.NORMAL, Character.Race.ORC, true, true, Character.Gender.MALE, 150, 150, 130, 130);
            Character worker_Jimi = new Character("worker Jimi", Character.Condition.NORMAL, Character.Race.ORC, true, false, Character.Gender.MALE, 100, 100, 150, 200);
            Character hunter = new Character("hunter", Character.Condition.NORMAL, Character.Race.ELF, true, true, Character.Gender.MALE, 46, 100, 100, 80);
            Character_With_Magic evil_wizard = new Character_With_Magic("evil wizard", Character.Condition.NORMAL, Character.Race.GOBLIN, true, true, Character.Gender.MALE, 300, 300, 300, 200, 200, 200);

            //Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.WriteLine(worker_John.ToString());
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine(worker_Jimi.ToString());
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine(hunter.ToString());
            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine(evil_wizard.ToString());
            //Console.ResetColor();

            /* Действующие лица */

            Poisonous_Saliva p_saliva_L = new Poisonous_Saliva(1);
            Poisonous_Saliva p_saliva_B = new Poisonous_Saliva(30);
            Staff_Lightning staff_L = new Staff_Lightning(20, 20);
            Frog_Legs_Decort lapkee = new Frog_Legs_Decort();
            Basilisk_Eye bas_eye = new Basilisk_Eye();

            evil_wizard.Pick_Up_An_Artefact(p_saliva_L);

            Console.WriteLine($"Охотник за головами темных магов {hunter.Get_Name()} наконец выследил свою добычу {evil_wizard.Get_Name()}, он готовился к этому дню на протяжении года," +
            " постепенно подбираясь к магу, он шел по следам его бесчинств, но сегодня он точно отомстит этому негодяю," +
            " не зря же он собрал такую огромную коллекцию артефактов." + '\n');

            Thread.Sleep(8000);

            worker_John.Pick_Up_An_Artefact(staff_L);
            worker_Jimi.Pick_Up_An_Artefact(staff_L);
            worker_John.Pick_Up_An_Artefact(bas_eye);
            worker_Jimi.Pick_Up_An_Artefact(bas_eye);
            worker_Jimi.Pick_Up_An_Artefact(bas_eye);

            hunter.Pick_Up_An_Artefact(p_saliva_B);
            hunter.Pick_Up_An_Artefact(lapkee);
            hunter.Pick_Up_An_Artefact(lapkee);
            hunter.Pick_Up_An_Artefact(bas_eye);

            Console.WriteLine($"Охотник отвлекся и не заметил, как {evil_wizard.Get_Name()} подобрался к двум бедным работягам {worker_Jimi.Get_Name()} и {worker_John.Get_Name()}," +
            $" отравил их ядовитой слюной, делал он это из жажды нажив," +
            $" т к знал, что у них хранится клад артефактов.");

            Thread.Sleep(7000);

            evil_wizard.Use_Artefact(p_saliva_L, worker_Jimi);
            evil_wizard.Use_Artefact(p_saliva_L, worker_John);
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 5; ++i)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Здоровье {worker_Jimi.Get_Name()} : {worker_Jimi.Get_Health_now()}");
                Thread.Sleep(1000);
                Console.WriteLine($"Здоровье {worker_John.Get_Name()} : {worker_John.Get_Health_now()}");
            }
            Console.ResetColor();

            Thread.Sleep(4000);

            Console.WriteLine($"Чувствуя вкус приближающейся победы, маг потерял бдительность, эта секунда и нужна была {hunter.Get_Name()}. Он парализовал и отравил злого мага и " +
            $"стал ждать когда подействует отрава и маг не умрет.");

            Thread.Sleep(4000);

            hunter.Use_Artefact(bas_eye, evil_wizard);
            hunter.Use_Artefact(p_saliva_B, evil_wizard);
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 10; ++i)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Здоровье {evil_wizard.Get_Name()} : {evil_wizard.Get_Health_now()}");
                if (evil_wizard.Get_Health_now() == 0)
                {
                    break;
                }
            }
            Console.ResetColor();
            Console.WriteLine($"Параллельно с ожиданием он стал лечить лягушачьими лапками работяг {worker_Jimi.Get_Name()} и {worker_John.Get_Name()}.");
            hunter.Use_Artefact(lapkee, worker_John);
            hunter.Use_Artefact(lapkee, worker_Jimi);
            Console.WriteLine($"В благодарность за спасение эти бедные существа поделились своим сокровищем с их спасителем и он снова отправился на поиски приключений");
            worker_John.Transfer_An_Artefact_To_Another_Character(staff_L, hunter);
            worker_John.Transfer_An_Artefact_To_Another_Character(bas_eye, hunter);
            worker_Jimi.Transfer_An_Artefact_To_Another_Character(bas_eye, hunter);

        }
        static void History3()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                   History 3" + '\n');
            Console.ResetColor();
            Thread.Sleep(4000);
            Character_With_Magic dark_wizard = new Character_With_Magic("dark wizard", Character.Condition.NORMAL, Character.Race.ORC, true, true, Character.Gender.MALE, 400, 1000, 1000, 10000, 1000, 1000);
            Character_With_Magic light_wizard = new Character_With_Magic("light wizard", Character.Condition.NORMAL, Character.Race.ELF, true, true, Character.Gender.MALE, 400, 1000, 1000, 10000, 1000, 1000);
            Character old_orc = new Character("old ork", Character.Condition.NORMAL, Character.Race.ORC, true, true, Character.Gender.MALE, 300, 10, 10, 300);
            Character first_orc = new Character("strong ork", Character.Condition.NORMAL, Character.Race.ORC, true, true, Character.Gender.MALE, 80, 1000, 1000, 70);
            Character second_orc = new Character("fast ork", Character.Condition.NORMAL, Character.Race.ORC, true, true, Character.Gender.MALE, 60, 300, 300, 30);
            Character third_orc = new Character("clever ork", Character.Condition.NORMAL, Character.Race.ORC, true, true, Character.Gender.MALE, 100, 500, 500, 20);
           
            Poisonous_Saliva p_saliva = new Poisonous_Saliva(10);
            Antidote antid = new Antidote(true,true);
            Revive revive = new Revive(true, true);
            Add_Health add_h = new Add_Health(false, true);
            Armor arm = new Armor(false, false);
            Living_Water_Bottle liv_bot_Big = new Living_Water_Bottle(Artefact.Bottles.BIG);
            Living_Water_Bottle liv_bot_Small = new Living_Water_Bottle(Artefact.Bottles.SMALL);
            Staff_Lightning st_ligh = new Staff_Lightning(999, 999);
            Frog_Legs_Decort fr_l_d = new Frog_Legs_Decort();

            light_wizard.Learn(add_h);
            light_wizard.Learn(revive);
            light_wizard.Learn(antid);
            light_wizard.Learn(arm);

            light_wizard.Pick_Up_An_Artefact(liv_bot_Small);

            dark_wizard.Pick_Up_An_Artefact(st_ligh);

            old_orc.Pick_Up_An_Artefact(liv_bot_Big);
            old_orc.Pick_Up_An_Artefact(fr_l_d);


            Console.WriteLine($"Эта история повествует о самом страшном сражении, схватке, которая покажет, что же всё-таки сильнее добро или зло, битве между сильнейшими" +
            $" магами света и тьмы {light_wizard.Get_Name()} и {dark_wizard.Get_Name()} , которые были врагами всю свою жизнь. Так получилось, что схватку маги устроили на земле орков, королевстве арадон." + '\n');

            Thread.Sleep(8000);
            
            dark_wizard.Pick_Up_An_Artefact(p_saliva);
            dark_wizard.Use_Artefact(p_saliva, old_orc);
            dark_wizard.Use_Artefact(p_saliva, first_orc);
            dark_wizard.Use_Artefact(p_saliva, second_orc);
            dark_wizard.Use_Artefact(p_saliva, third_orc);
            for (int i = 0; i < 3; ++i)
            {
            Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(1000);
                if (old_orc.Get_Health_now() != 0)
                {
                    Console.WriteLine($"Здоровье {old_orc.Get_Name()} : {old_orc.Get_Health_now()}");
                }
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Здоровье {first_orc.Get_Name()} : {first_orc.Get_Health_now()}");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Здоровье {second_orc.Get_Name()} : {second_orc.Get_Health_now()}");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Здоровье {third_orc.Get_Name()} : {third_orc.Get_Health_now()}");
            }
            Console.ResetColor();
            Console.WriteLine("Не бывает битв без жертв, особенно, если в ней участвует злейшее на свете существо. темный маг " +
                "отравил большую часть населения королевства дабы ослабить светлого мага, который не мог пройти мимо раненых, ослабленных ии отравленных орков и исцелял их, тратя запасы драгоценной маны." + '\n');

            Thread.Sleep(10000);

            light_wizard.Tell(revive,old_orc);
            if (old_orc.Get_Condition() != Character.Condition.DEAD)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{old_orc.Get_Name()} ожил");
                Console.ResetColor();
            }
            Thread.Sleep(3000);
            light_wizard.Tell(add_h, old_orc, 20);

            light_wizard.Tell(antid, first_orc);
            light_wizard.Tell(antid, second_orc);
            light_wizard.Tell(antid, third_orc);

            Console.WriteLine("но ничего не делается зря и светлый маг своим добрым поступком, который стоил ему не мало сил, увеличил свои шансы на победу, ведь у него появилось много новых союзников," +
                " конечно, орки были благодарны, но ещё одной причиной, которая двигала их на союз со светлым магом – это месть." + '\n');
            Thread.Sleep(12000);
            Console.WriteLine($"В день битвы на поле ссобрались союзники светлого мага,  {light_wizard.Get_Name()} и их противник. {dark_wizard.Get_Name()} испугался численного превосходства служителя добра, поэтому" +
                $" решил взять этот бой хитростью. Он предложил пойти на мировую и в тот самый момент, когда маги пожали руки {dark_wizard.Get_Name()} , решил использовать последний козырь в рукаве, а затем нанес" +
                " сильнейший удар посохом, на который магический атрефакт был способен." + '\n');
            dark_wizard.Use_Artefact(st_ligh, light_wizard, 999);
            Console.WriteLine($"И у светлого мага осталось только {light_wizard.Get_Health_now()} hp." + '\n');
            Thread.Sleep(15000);
            Console.WriteLine("белый маг находился на грани жизни и смерти, в то время как орки вступили в сражение с ослабленым к тому времени темным магом, лишь по этой причине все орки не умерли сразу." +
                $" Но темный маг не знал, что самый неприметный и старый орк спасет мир от зла. {old_orc.Get_Name()} владел ценнейшим артефактом, который мог спасти жизнь и магу, и его" +
                " соплеменникам, артефактом, который передавался из поколения в поколение в его семье, и вот настал час его использовать." + '\n');
            Thread.Sleep(15000);
            old_orc.Use_Artefact(liv_bot_Big, light_wizard);
            Console.WriteLine($"Белый маг и не надеялся на спасение, когда увидел подбегающего к нему орка, в руках которого находился артефакт, и как только {light_wizard.Get_Name()} был исцелен самый старый и" +
                " отважный орк погиб от выстрела темным посохом, этот момент стал переломным в битве, т к каждый орк без исключения любил героя того страшного дня, жертвуя собой орки помогли светлому магу, сбив" +
                $" с ног и отобрав у темного маг посох, орки избили до смерти {dark_wizard.Get_Name()}." + '\n');
            Thread.Sleep(15000);
            dark_wizard.Use_Artefact(st_ligh, old_orc, 10);

            if (old_orc.Get_Condition() == Character.Condition.DEAD)
            {
                Console.WriteLine($"{old_orc.Get_Name()} умер");
            }
            Thread.Sleep(2000);
            dark_wizard.Transfer_An_Artefact_To_Another_Character(st_ligh,light_wizard);
        while(dark_wizard.Get_Condition() != Character.Condition.DEAD)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                first_orc.Hit(dark_wizard, 100);
                Console.WriteLine($"{first_orc.Get_Name()} ударил {dark_wizard.Get_Name()}");
                Console.WriteLine($"Здоровье {dark_wizard.Get_Name()} : {dark_wizard.Get_Health_now()}" + '\n');
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Yellow;
                second_orc.Hit(dark_wizard, 60);
                Console.WriteLine($"{second_orc.Get_Name()} ударил {dark_wizard.Get_Name()}");
                Console.WriteLine($"Здоровье {dark_wizard.Get_Name()} : {dark_wizard.Get_Health_now()}" + '\n');
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                third_orc.Hit(dark_wizard, 40);
                Console.WriteLine($"{third_orc.Get_Name()} ударил {dark_wizard.Get_Name()}");
                Console.WriteLine($"Здоровье {dark_wizard.Get_Name()} : {dark_wizard.Get_Health_now()}" + '\n');
                Thread.Sleep(1000);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{dark_wizard.Get_Name()} умер" + '\n');
            Console.ResetColor();
            Console.WriteLine("И добро наконец-то одержало верх над злом....");
        }
        static void History4()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                   History 4" + '\n');
            Thread.Sleep(2000);
            Console.ResetColor();
            Character_With_Magic light_wizard = new Character_With_Magic("Gendelf", Character.Condition.NORMAL, Character.Race.PERSON, true, true, Character.Gender.MALE, 60, 1000, 1000, 10000, 1000, 1000);
            Character mam_elf = new Character("mam elf", Character.Condition.NORMAL, Character.Race.ELF, true, true, Character.Gender.FEMALE, 30, 100, 100, 300);
            Character dad_elf = new Character("dad elf", Character.Condition.NORMAL, Character.Race.ELF, true, true, Character.Gender.MALE, 32, 400, 400, 70);
            Character sun_elf = new Character("sun elf", Character.Condition.PARALYZED, Character.Race.ELF, true, false, Character.Gender.MALE, 10, 10, 10, 30);
            Character daughter_elf = new Character("daughter elf", Character.Condition.SICK, Character.Race.ELF, true, true, Character.Gender.FEMALE, 15, 30, 1, 20);
            Character goblin = new Character("goblin", Character.Condition.NORMAL, Character.Race.GOBLIN, true, true, Character.Gender.MALE, 22, 500, 500, 70);

            Wither_Away w_away = new Wither_Away(true, true);
            Cure cure = new Cure(false, true);
            Armor armor = new Armor(true, false);

            light_wizard.Learn(w_away);
            light_wizard.Learn(cure);
            light_wizard.Learn(armor);

            Console.WriteLine("Всю историю существования Королевство эльфов процветало, т к эта раса была более эгоистичной, чем остальные и редко приходила на помощь во время воин" + '\n');
            Thread.Sleep(5000);
            Console.WriteLine("Народы, которые не получали поддержки эльфов проклинали их" + '\n');
            Thread.Sleep(3000);
            Console.WriteLine("И в один ужасный для эльфов день это сильнейшее проклятие вступило в силу, началась эпидемия, болезнь поражала лишь детей" + '\n');
            Thread.Sleep(3000);
            Console.WriteLine("И тогда отцы и матери взмолились о помощи, ведь это невыносимо смотреть на смерть собственных детей" + '\n');
            Thread.Sleep(3000);
            Console.WriteLine("На помощь эльфийскому народу пришли светлые маги. Они тратили свою манну до последней капли, дабы излечить детей" + '\n');
            Thread.Sleep(3000);
            Console.WriteLine($"Одного из них звали {light_wizard.Get_Name()}. В тот день в очередной раз светлый маг спешил на помощь к эльфийской семье, сын" +
                $" которых был парализован, а дочь - тяжело больна" + '\n');
            Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("До:" + '\n');
            Console.WriteLine($"Состояние {sun_elf.Get_Name()} : {sun_elf.Get_Condition()}.");
            Console.WriteLine($"Состояние {daughter_elf.Get_Name()} : {daughter_elf.Get_Condition()}." + '\n');
            light_wizard.Tell(w_away, sun_elf);
            light_wizard.Tell(cure, daughter_elf);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("После:" + '\n');
            Console.WriteLine($"Состояние {sun_elf.Get_Name()} : {sun_elf.Get_Condition()}.");
            Console.WriteLine($"Состояние {daughter_elf.Get_Name()} : {daughter_elf.Get_Condition()}." + '\n');
            Console.ResetColor();
            Thread.Sleep(5000);

            Console.WriteLine($"{light_wizard.Get_Name()} исполнил свой долг и собирался уже уходить, как вдруг на семью напал напал злой и голодный гоблин " + '\n');
            Thread.Sleep(3000);
            Console.WriteLine($"В схватку с ним вступил глава семейства - {dad_elf.Get_Name()} " + '\n');
            Thread.Sleep(3000);
            Console.WriteLine($"{light_wizard.Get_Name()} понимал, что эльф не востоит против гоблина и воспользовался заклинанием защиты" + '\n');
            Thread.Sleep(3000);
            light_wizard.Tell(armor, dad_elf, 20);

            while(goblin.Get_Health_now() != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(1000);
                goblin.Hit(dad_elf, 40);
                Console.WriteLine($"Здоровье {dad_elf.Get_Name()} : {dad_elf.Get_Health_now()}");
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(1000);
                dad_elf.Hit(goblin, 30);
                if (goblin.Get_Condition() == Character.Condition.DEAD)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{goblin.Get_Name()} умер");
                    break;
                }
                Console.WriteLine($"Здоровье {goblin.Get_Name()} : {goblin.Get_Health_now()}");
            }
            Console.ResetColor();
            Console.WriteLine($"После этой схватки они зажарили гоблина и в благодарность семья эльфов поделилась частью добычи с {light_wizard.Get_Name()}" + '\n');
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("                    The END!!!              ");
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            //Character_With_Magic joker = new Character_With_Magic("joker", Character_With_Magic.Condition.NORMAL, Character_With_Magic.Race.ELF, true, true, Character_With_Magic.Gender.MALE, 29, 80, 80, 20, 300, 100);
            //Character_With_Magic old_hermit = new Character_With_Magic("old hermit", Character_With_Magic.Condition.NORMAL, Character_With_Magic.Race.GOBLIN, true, true, Character_With_Magic.Gender.MALE, 50, 100, 90, 150, 400, 200);
            //Dead_Water_Bottle d = new Dead_Water_Bottle(Artefact.Bottles.MEDIUM);
            //Console.WriteLine(joker.Inventory_To_String());
            //joker.Pick_Up_An_Artefact(d);
            //Console.WriteLine(joker.Inventory_To_String());
            //joker.Use_Artefact(d, old_hermit);
            //Console.WriteLine(joker.ToString());
            //Console.WriteLine(old_hermit.ToString());
            Character joker = new Character("joker", Character.Condition.NORMAL, Character.Race.ELF, true, true, Character.Gender.MALE, 29, 80, 80, 20);
            Dead_Water_Bottle d = new Dead_Water_Bottle(Artefact.Bottles.MEDIUM);
            joker.Pick_Up_An_Artefact(d);
            joker.Use_Artefact(d, joker);
            //History1();
            //Thread.Sleep(3000);
            //History2();
            //Thread.Sleep(3000);
            //History3();
            //Thread.Sleep(3000);
            //History4();
        }
    }
}