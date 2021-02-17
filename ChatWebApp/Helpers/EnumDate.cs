using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.Helpers
{
    public enum EnumDate
    {
        Minute = 1,
        TenMinute = 10,
        Hour = 60,
        Day = Hour*24,
        Week = Day*7,
        Moon = Day*30
    }
}
