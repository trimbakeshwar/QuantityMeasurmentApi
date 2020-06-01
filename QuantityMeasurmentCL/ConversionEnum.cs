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
            public const decimal INCH = ((decimal)(1.0));
            public const decimal INCH_TO_FEET = ((decimal)(1.0 / 12.0));
            public const decimal FEET_TO_INCH = ((decimal)(1 * 12.0));
            public const decimal FEET_TO_YARD = ((decimal)(1.0 / 3.0));
            public const decimal YARD_TO_FEET = ((decimal)(1.0 * 3.0));
            public const decimal INCH_TO_YARD = ((decimal)(1.0 / 36.0));
            public const decimal YARD_TO_INCH = ((decimal)(1 * 36.0));           
            public const decimal INCH_TO_CM = ((decimal)(1 * 2.5));
            public const decimal CM_TO_INCH = ((decimal)(1 / 2.5));
            //conversions according to volumes
            public const decimal LITRE = ((decimal)(1.0));
            public const decimal GALLON_TO_LITRE = ((decimal)(1.0 * 3.78));
            public const decimal LITRE_TO_GALLON = ((decimal)(1.0 / 3.78));
            public const decimal MILLILITER_TO_LITRE = ((decimal)(1.0 / 1000.0));
            public const decimal LITRE_TO_MILLILITER = ((decimal)(1.0 * 1000.0));
            // conversions according to weights
            public const decimal KILOGRAM = ((decimal)(1.0));
            public const decimal GRAMS_TO_KILOGRAM = ((decimal)(1.0 / 1000.0));
            public const decimal KILOGRAM__TO_GRAMS = ((decimal)(1.0 * 1000.0));
            public const decimal TONNE_TO_KILOGRAM = ((decimal)(1.0 * 1000.0));
            public const decimal KILOGRAM_TO_TONNE = ((decimal)(1.0 / 1000.0));
            public const decimal GRAM_TO_TONNE = ((decimal)(1.0 / (1000.0 * 1000.0)));
            public const decimal TONNE_TO_GRAMS = ((decimal)(1.0 *1000.0 * 1000.0));
            //conversions according to temperature
            public const decimal CELSIUS = ((decimal)(1.0 * 2.12));
            public const decimal FAHRENHEIT_TO_CELSIUS = ((decimal)(1.0 / 2.12));
            public const decimal CELSIUS_TO_FAHRENHEIT = ((decimal)(1.0 * 33.8));
            //Enums for 
        }
        public decimal UnitConversion(decimal units, decimal value)
        {
            //double values = Convert.ToDouble(units);
            return value * units;
        }
      
    }
}
