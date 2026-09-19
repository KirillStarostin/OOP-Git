namespace Starostin.KD_ZIVT_251_OOP6
{
    class Programm
    {
        public delegate double MyDel(int[] a);
        static void Main()
        {
            // Создаем 100 ПК
            List<Computer> computers = Computer.Generate100();

            // Фильтруем по типу процессора
            List<Computer> FilterbyCPU = computers
                .Where(comp => comp.typeCPU == TypeCPU.Настольный)
                .ToList();

            Console.WriteLine($"Компьютеры с настольным процессором:");
            foreach (var pc in FilterbyCPU)
                Console.WriteLine($"  {pc.namePC}: {pc.typeCPU}");
            Console.WriteLine();

            // Фильтруем по типу процессора и производителю
            List<Computer> FilterbyCPUandManufacturer = computers
                .Where(comp => comp.typeCPU == TypeCPU.Настольный && comp.manufacturerCPU == ManufacturerCPU.Intel)
                .ToList();

            Console.WriteLine($"Компьютеры с настольным процессором Intel:");
            foreach (var pc in FilterbyCPUandManufacturer)
                Console.WriteLine($"  {pc.namePC}: {pc.typeCPU} {pc.manufacturerCPU}");

            // Фильтруем по пользователям и ОЗУ
            List<Computer> FilterbyUsersandRAM = computers
                .Where(comp => comp.usersPC.Contains("Starostin.KD") && comp.capacityRAM == 16)
                .ToList();

            Console.WriteLine($"Мои компьютеры с ОЗУ 16Гб:");
            foreach (var pc in FilterbyUsersandRAM)
                Console.WriteLine($"  {pc.namePC}: {string.Join(",", pc.usersPC)} {pc.capacityRAM}Гб");

            // Сортируем по типу процессора
            List<Computer> sortCPU = computers
                .OrderBy(comp => comp.typeCPU)
                .ToList();

            Console.WriteLine($"Сортировка по типу ЦП");
            foreach (var pc in sortCPU)
                Console.WriteLine($"  {pc.namePC}: {pc.typeCPU} {pc.manufacturerCPU}");

            // Сортируем по типу процессора и названию производителя
            List<Computer> sortbyCPUandManufacturer = computers
                .OrderBy(comp => comp.typeCPU)
                .ThenBy(comp => comp.manufacturerCPU)
                .ToList();

            Console.WriteLine($"Сортировка по типу ЦП и производителю");
            foreach (var pc in sortbyCPUandManufacturer)
                Console.WriteLine($"  {pc.namePC}: {pc.typeCPU} {pc.manufacturerCPU}");
            Console.WriteLine();

            // SELECT
            var select = computers.Select(comp => new
            {
                name = comp.namePC,
                ClockSpeed = comp.clockSpeedCPU,
                RAM = comp.capacityRAM,
                soft = comp.installedSoftware
            }).ToList();

            Console.WriteLine($"ПК: Частота-ОЗУ: ПО");
            foreach (var pc in select)
                Console.WriteLine($"  {pc.name}: {pc.ClockSpeed} МГц-{pc.RAM} Гб: {string.Join(",", pc.soft)}");

            // Заполняем List<Manufacturer>

            List<Manufacturer> manufacturers = new List<Manufacturer>
            {
                new Manufacturer(ManufacturerCPU.Intel,   Country.США,        121000),
                new Manufacturer(ManufacturerCPU.AMD,     Country.США,         26000),
                new Manufacturer(ManufacturerCPU.Apple,   Country.США,        164000),
                new Manufacturer(ManufacturerCPU.Байкал,  Country.Россия,        500),
                new Manufacturer(ManufacturerCPU.GTS,  Country.Китай,      207000),
                new Manufacturer(ManufacturerCPU.OPD, Country.ЮжнаяКорея, 270000),
                new Manufacturer(ManufacturerCPU.Fly,    Country.Тайвань,     73000)
            };
            Console.WriteLine();

            var join = from comp in computers
                         join manuf in manufacturers
                             on comp.manufacturerCPU equals manuf.Name
                         select new
                         {
                             NamePC = comp.namePC,
                             CPU = comp.manufacturerCPU,
                             TypeCPU = comp.typeCPU,
                             Frequency = comp.clockSpeedCPU,
                             RAM = comp.capacityRAM,
                             ManufacturerName = manuf.Name,
                             Country = manuf.CountryManufacturer,
                             Employees = manuf.countEmployees
                         };

            // Вывод результата
            foreach (var item in join)
            {
                Console.WriteLine(
                    $"{item.NamePC} | " +
                    $"{item.CPU, -10} | " +
                    $"{item.Country, -15} | " +
                    $"{item.Employees,-20}");
            }
            Console.WriteLine();

            

            // Метод удаляющий русские буквы
            string RemoveRussianLetters(string str)
            {
                return System.Text.RegularExpressions.Regex.Replace(str, @"[А-Яа-яЁё]", "");
            }

            Console.WriteLine(RemoveRussianLetters("1C Предприятие"));
            Console.ReadKey();
        }
    }
}
