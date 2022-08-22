﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightModel
{
    public static class EpochToDateTime
    {

        public static DateTime GetDateTimeFromeEpoch(double epochTimeStamp)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            start = start.AddSeconds(epochTimeStamp).AddHours(3);
            return start;
        }
    }
}
