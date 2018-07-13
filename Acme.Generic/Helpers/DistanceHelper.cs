﻿using System;

namespace Acme.Generic.Helpers
{
    public static class DistanceHelper
    {
        public static double KiloMetersToMiles(double kiloMeters, int precision = 2)
        {
            double result = kiloMeters * 0.6213712;
            result = Math.Round(result, precision);

            return result;
        }

        public static double MilesToKiloMeters(double miles, int precision = 2)
        {
            double result = miles * 1.609344;
            result = Math.Round(result, precision);

            return result;
        }
    }
}
