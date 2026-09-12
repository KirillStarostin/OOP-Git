namespace Starostin.KD_ZIVT_251_OOP6
{
    class Programm
    {
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
        }
    }
}
