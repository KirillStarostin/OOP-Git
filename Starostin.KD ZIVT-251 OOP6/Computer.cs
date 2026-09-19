using System;
using System.Collections.Generic;
using System.Text;

namespace Starostin.KD_ZIVT_251_OOP6
{
    public enum TypeCPU { Настольный, Серверный}
    public enum ManufacturerCPU { Intel, AMD, Apple, Байкал, GTS, OPD, Fly};
    public enum TypeOS { Windows_10, Windows_11, AstraLinux_SE, RedOS, MacOS};
    public enum regionPC { OMS, MSK, TMN, LEN, HAN, TOM, ORB, IRK, KAZ, TGZ, BLG, UFA}
    interface IComputer
    {
        TypeCPU typeCPU { get; }
        ManufacturerCPU manufacturerCPU { get; }
        TypeOS typeOS { get; }
        int clockSpeedCPU { get; set; }
        int capacityRAM { get; set; }
        List<string> installedSoftware { get; set; }
        List<string> usersPC { get; set; }
    }
    interface IOverclock
    {
        void OverclockTheComputer();
    }
    public delegate void UserAddedHandler(string userName);
    public delegate void CPUReplacedHandler(string oldCPU, string newCPU);
    public delegate void SoftwareInstalledHandler(string softwareName);
    public delegate void RAMReplacedHandler(int oldRAM, int newRAM);
    public class Computer: IOverclock, IComputer
    {
        private static readonly Random random = new Random();

        // Массивы для генерации
        public static string[] SoftwareNames = {
            "Telegram", "MS Word", "Edge", "MS Excel", "Steam",
            "MS Visual Studio", "Yandex", "iTunes", "Discord",
            "Happ", "Skype", "1С Предприятие", "Kate", "NVIDIA App", "7-Zip"
        };
        public static string[] UserNames = {
            "Starostin.KD", "Ivko.MN", "Lepilina.PA", "Petrenko.ES", "Zhmaylo.AN",
            "Malyash.MG", "Namestnikova.EA", "Pushkarev.DA", "Petuhova.YuA", "Gryzlov.AA",
            "Dolidze.LG","Chepurnaya.SYu","Eremina.GYu","Alekseev.AS","Kushvid.AS"
        };
        public TypeCPU typeCPU { get; }
        public ManufacturerCPU manufacturerCPU { get; }
        public TypeOS typeOS { get; }
        public int clockSpeedCPU { get; set; }
        public int capacityRAM { get; set; }
        public List<string> installedSoftware { get; set; }
        public List<string> usersPC { get; set; }
        bool is_Overcloked = false;
        public string namePC;

        // События
        public event UserAddedHandler NewUserAdded;
        public event CPUReplacedHandler CPUReplaced;
        public event SoftwareInstalledHandler SoftwareInstalled;
        public event RAMReplacedHandler RAMReplaced;

        // Конструктор без параметров
        public Computer()
        {
            typeCPU = TypeCPU.Настольный;
            manufacturerCPU = ManufacturerCPU.Intel;
            typeOS = TypeOS.Windows_11;
            clockSpeedCPU = 3600;
            capacityRAM = 16;
            installedSoftware = new List<string> { SoftwareNames[5], SoftwareNames[7], SoftwareNames[10] };
            usersPC = new List<string> { UserNames[1] };
            namePC = "OMS-2510";
        }
        // Конструктор с параметрами
        public Computer(string namepc, TypeCPU typecpu, ManufacturerCPU manufacturercpu, TypeOS typeos, int clockspeedcpu, int capacityram, List<string> installedsoftware, List<string> userspc)
        {
            typeCPU = typecpu;
            manufacturerCPU = manufacturercpu;
            typeOS = typeos;
            clockSpeedCPU = clockspeedcpu;
            capacityRAM = capacityram;
            installedSoftware = installedsoftware;
            usersPC = userspc;
            namePC = namepc;
        }

        // Метод разгона
        public void OverclockTheComputer()
        {
            // Проверка на разгон
            if (is_Overcloked)
            {
                Console.WriteLine($"{typeCPU} {manufacturerCPU}: уже разогнан!");
                return;
            }

            Console.WriteLine($"Адский разгон {typeCPU} ({manufacturerCPU})...");
            Console.WriteLine($"Было: {clockSpeedCPU} МГц");

            // Логика в зависимости от типа процессора
            double overclockingLevel = typeCPU switch
            {
                TypeCPU.Серверный => 2.25,
                TypeCPU.Настольный => 1.50,
            };
            // Разгоняем
            clockSpeedCPU = (int)(clockSpeedCPU * overclockingLevel);
            
            // Ставим метку разгона
            is_Overcloked = true;
            Console.WriteLine($"   Стало: {clockSpeedCPU} МГц");
            Console.WriteLine($"Разгон завершён!");
        }

        // Метод генерации объектов
        public static Computer Generate()
        {
            // Случайный процессор
            TypeCPU cpu = (TypeCPU)random.Next(Enum.GetValues(typeof(TypeCPU)).Length);

            // Случайный производитель
            ManufacturerCPU manufacturer = (ManufacturerCPU)random.Next(
                Enum.GetValues(typeof(ManufacturerCPU)).Length);

            // Случайная ОС
            TypeOS os = (TypeOS)random.Next(Enum.GetValues(typeof(TypeOS)).Length);

            // Случайная частота (от 1000 до 5000 МГц)
            int frequency = random.Next(1000, 5001);

            // Случайный объём ОЗУ (4, 8, 16, 32, 64 ГБ)
            int[] ramOptions = { 4, 8, 16, 32, 64 };
            int ram = ramOptions[random.Next(ramOptions.Length)];

            // Случайное ПО (от 1 до 5 программ)
            List<string> software = new List<string>();
            int softwareCount = random.Next(1, 6);
            for (int i = 0; i < softwareCount; i++)
            {
                string sw = SoftwareNames[random.Next(SoftwareNames.Length)];
                if (!software.Contains(sw))
                    software.Add(sw);
                else
                    i--;
            }

            // Случайные пользователи (от 1 до 3)
            List<string> users = new List<string>();
            int userCount = random.Next(1, 4);
            for (int i = 0; i < userCount; i++)
            {
                string user = UserNames[random.Next(UserNames.Length)];
                if (!users.Contains(user))
                    users.Add(user);
                else
                    userCount--;
            }

            // Случайные имена ПК
            string name = $"{(regionPC)random.Next(Enum.GetValues(typeof(regionPC)).Length)}-{random.Next(1000,10000)}";

            // Создаём экземпляр
            return new Computer(name, cpu, manufacturer, os, frequency, ram, software, users);
        }

        // Метод генерации 100 ПК
        public static List<Computer> Generate100()
        {
            List<Computer> computers = new List<Computer>();

            for (int i = 0; i < 100; i++)
            {
                computers.Add(Generate());
            }

            return computers;
        }


        public void AddUser(string user)
        {
            usersPC.Add(user);
            NewUserAdded?.Invoke(user);
        }

        public void RemoveUser(string user)
        {
            usersPC.Remove(user);
            NewUserAdded?.Invoke(user);
        }
    }
}
