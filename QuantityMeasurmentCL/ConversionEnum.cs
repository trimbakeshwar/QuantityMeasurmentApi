using System;
using System.Collections.Generic;
using System.Text;

namespace QuantityMeasurmentCL
{
    public class ConversionEnum
    {
        public struct Unit
        {
            //conversions according to lengths
            public const double INCH = 1.0;
            public const double INCH_TO_FEET = (1.0 / 12.0);
            public const double FEET_TO_INCH = (1 * 12.0);
            public const double FEET_TO_YARD = (1.0 / 3.0);
            public const double YARD_TO_FEET = (1.0 * 3.0);
            public const double INCH_TO_YARD = (1.0 / 36.0);
            public const double YARD_TO_INCH = (1 * 36.0);           
            public const double INCH_TO_CM = (1 * 2.5);
            public const double CM_TO_INCH = (1 / 2.5);
            //conversions according to volumes
            public const double LITRE = (1.0);
            public const double GALLON_TO_LITRE = (1.0 * 3.78);
            public const double LITRE_TO_GALLON = (1.0 / 3.78);
            public const double MILLILITER_TO_LITRE = (1.0 / 1000.0);
            public const double LITRE_TO_MILLILITER = (1.0 * 1000.0);
            // conversions according to weights
            public const double KILOGRAM = (1.0);
            public const double GRAMS_TO_KILOGRAM = (1.0 / 1000.0);
            public const double KILOGRAM__TO_GRAMS = (1.0 * 1000.0);
            public const double TONNE_TO_KILOGRAM = (1.0 * 1000.0);
            public const double KILOGRAM_TO_TONNE = (1.0 / 1000.0);
            public const double GRAM_TO_TONNE = (1.0 / (1000.0 * 1000.0));
            public const double TONNE_TO_GRAMS = (1.0 *1000.0 * 1000.0);
            //conversions according to temperature
            public const double CELSIUS = (1.0 * 2.12);
            public const double FAHRENHEIT_TO_CELSIUS = (1.0 / 2.12);
            //Enums for 
        }
        public double UnitConversion(double units, double value)
        {
            //double values = Convert.ToDouble(units);
            return value * units;
        }
      
    }
}
