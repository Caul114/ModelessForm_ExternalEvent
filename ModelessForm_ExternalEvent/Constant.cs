using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelessForm_ExternalEvent
{
    public class Constant
    {
        /// <summary>
        /// Convertitore da millimetri a piedi.
        /// </summary>
        const double _mmToFeet = 0.0032808399;

        public static double MmToFeet(double mmValue)
        {
            return mmValue * _mmToFeet;
        }

        /// <summary>
        /// Convertitore da piedi a millimetri.
        /// </summary>
        const double _mmToMill = 0.0032808399;

        public static double FeetToMm(double feetValue)
        {
            return feetValue / _mmToMill;
        }

        /// <summary>
        /// Convertitore da piedi a pollici.
        /// </summary>
        const double _feetToInc = 12;

        public static double FeetToInc(double feetValue, double incValue)
        {
            return (feetValue * _feetToInc + incValue);
        }

        /// <summary>
        /// Convertitore da pollici a piedi.
        /// </summary>
        const double _incToFeet = 0.083333;

        public static int[] IncToFeet(double incValue)
        {
            double temp = incValue* _incToFeet;
            int feet = (int)temp;
            double temp2 = (temp - (double)feet) * 12;
            int inc = (int)temp2 + 1;
            int[] values = new int[] { feet, inc };
            return values;
        }
    }
}
