using System;
using System.Collections.Generic;
using System.Text;

namespace Starostin.KD_ZIVT_251_OOP6
{
    enum TypeCPU { Настольный, Серверный}
    enum ManufacturerCPU { Intel, AMD, Apple, Байкал};
    enum TypeOS { Windows_10, Windows_11, AstraLinux_SE, RedOS, MacOS};
    interface IComputer
    {
        TypeCPU typeCPU { get; }
        ManufacturerCPU manufacturerCPU { get; }
        TypeOS typeOS { get; }
        int clockSpeedCPU { get; }
        int capacityRAM {  get; }
        List<string> installedSoftware { get; set; }
        List<string> usersPC { get; set; }
    }
    interface IOverclock
    {
        void OverclockTheComputer();
    }
    public class Computer: IOverclock, IComputer
    {
        TypeCPU typeCPU;
        ManufacturerCPU manufacturerCPU;
        TypeOS typeOS;
        int clockspeedCPU;
        int capacityRAM;
        List<string> installedSoftware;
        List<string> usersPC;
    }
}
