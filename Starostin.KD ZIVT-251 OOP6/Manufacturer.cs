using System;

namespace Starostin.KD_ZIVT_251_OOP6
{
    public enum Country { США, Россия, Китай , ЮжнаяКорея,  Тайвань}
    interface IManufacturer
    {
        ManufacturerCPU Name { get; set; }
        Country CountryManufacturer { get; set; }
        int countEmployees { get; set; }
    }
    public class Manufacturer : IManufacturer
    {
        public ManufacturerCPU Name { get; set; }
        public Country CountryManufacturer { get; set; }
        public int countEmployees { get; set; }

        public Manufacturer()
        {
            Name = ManufacturerCPU.Intel;
            CountryManufacturer = Country.США;
            countEmployees = 15067;
        }

        public Manufacturer(ManufacturerCPU name, Country country, int count)
        {
            Name = name;
            CountryManufacturer = country;
            countEmployees = count;
        }
    }
}