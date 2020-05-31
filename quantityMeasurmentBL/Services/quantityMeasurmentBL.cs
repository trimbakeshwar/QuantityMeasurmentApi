using quantityMeasurmentBL.interfaces;
using QuantityMeasurmentCL;
using QuantityMeasurmentRL.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static QuantityMeasurmentCL.ConversionEnum;

namespace quantityMeasurmentBL.Services
{
    public class quantitymeasurmentBL : IquantityMeasurmentBL
    {
        private IquantityMeasurmentRL measurmentRL;
        public quantitymeasurmentBL(IquantityMeasurmentRL measurmentRL)
        {
            this.measurmentRL = measurmentRL;
        }
        public ConversionModel Convert(ConversionModel Data)
        {
            Data.Result = Calculate(Data);
            return this.measurmentRL.Add(Data);
        }

        private decimal Calculate(ConversionModel data)
        {
            ConversionEnum coversionObj = new ConversionEnum();
            decimal value = data.Value;
            string units = data.OperationType;
            try
            {
                switch (units)
                {

                    case "INCH_TO_FEET":
                        return coversionObj.UnitConversion(Unit.INCH_TO_FEET, value);
                    case "FEET_TO_INCH":
                        return coversionObj.UnitConversion(Unit.FEET_TO_INCH, value);
                    case "FEET_TO_YARD":
                        return coversionObj.UnitConversion(Unit.FEET_TO_YARD, value);
                    case "YARD_TO_FEET":
                        return coversionObj.UnitConversion(Unit.YARD_TO_FEET, value);
                    case "INCH_TO_YARD":
                        return coversionObj.UnitConversion(Unit.INCH_TO_YARD, value);                      
                    case "YARD_TO_INCH":
                        return coversionObj.UnitConversion(Unit.YARD_TO_INCH, value);                       
                    case "INCH_TO_CM":
                        return coversionObj.UnitConversion(Unit.INCH_TO_CM, value);                       
                    case "CM_TO_INCH":
                        return coversionObj.UnitConversion(Unit.CM_TO_INCH, value);                       
                    case "LITRE":
                        return coversionObj.UnitConversion(Unit.LITRE, value);                       
                    case "GALLON_TO_LITRE":
                        return coversionObj.UnitConversion(Unit.GALLON_TO_LITRE, value);                       
                    case "LITRE_TO_GALLON":
                        return coversionObj.UnitConversion(Unit.LITRE_TO_GALLON, value);                       
                    case "MILLILITER_TO_LITRE":
                        return coversionObj.UnitConversion(Unit.MILLILITER_TO_LITRE, value);                       
                    case "LITRE_TO_MILLILITER":
                        return coversionObj.UnitConversion(Unit.LITRE_TO_MILLILITER, value);                       
                    case "KILOGRAM":
                        return coversionObj.UnitConversion(Unit.KILOGRAM, value);                       
                    case "GRAMS_TO_KILOGRAM":
                        return coversionObj.UnitConversion(Unit.GRAMS_TO_KILOGRAM, value);                       
                    case "KILOGRAM__TO_GRAMS":
                        return coversionObj.UnitConversion(Unit.KILOGRAM__TO_GRAMS, value);                       
                    case "TONNE_TO_KILOGRAM":
                        return coversionObj.UnitConversion(Unit.TONNE_TO_KILOGRAM, value);                       
                    case "KILOGRAM_TO_TONNE":
                        return coversionObj.UnitConversion(Unit.KILOGRAM_TO_TONNE, value);                       
                    case "GRAM_TO_TONNE":
                        return coversionObj.UnitConversion(Unit.GRAM_TO_TONNE, value);                        
                    case "TONNE_TO_GRAMS":
                        return coversionObj.UnitConversion(Unit.TONNE_TO_GRAMS, value);                       
                    case "FAHRENHEIT_TO_CELSIUS":
                        return coversionObj.UnitConversion(Unit.FAHRENHEIT_TO_CELSIUS, value);                       
                    case "CELSIUS_TO_FAHRENHEIT":
                        return coversionObj.UnitConversion(Unit.FAHRENHEIT_TO_CELSIUS, value);                        
                    default:
                        throw new Exception("not a valid type");                       
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public ConversionModel Delete(int Id)
        {
            return this.measurmentRL.Delete(Id);
        }

        public IEnumerable<ConversionModel> GetConversion()
        {
            return this.measurmentRL.GetConversion();
        }

        public ConversionModel GetConversion(int Id)
        {
            return this.measurmentRL.GetConversion(Id);
        }
    }
}
