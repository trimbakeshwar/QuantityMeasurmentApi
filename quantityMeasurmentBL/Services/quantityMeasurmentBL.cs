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
        public ConversionsModel Convert(ConversionsModel Data)
        {
            try
            {
                Data.Result = Calculate(Data);
                return this.measurmentRL.Add(Data);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        private decimal Calculate(ConversionsModel data)
        {
            try
            {
                ConversionEnum coversionObj = new ConversionEnum();
                decimal value = data.Value;
                string units = data.OperationType;
           
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
                        return ((value - 32) * 5 / 9);
                    case "CELSIUS_TO_FAHRENHEIT":
                        return ((value * 9 / 5) + 32);
                    default:
                        throw new Exception("not a valid type");                       
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public ConversionsModel Delete(int Id)
        {
            try
            {
                return this.measurmentRL.Delete(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<ConversionsModel> GetConversion()
        {
            try 
            { 
                return this.measurmentRL.GetConversion();
            }
             catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ConversionsModel GetConversion(int Id)
        {
            try
            {
                return this.measurmentRL.GetConversion(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
