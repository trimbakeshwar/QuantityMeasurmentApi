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
                Data.Result = (decimal)Calculate(Data);
                return this.measurmentRL.Add(Data);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        private double Calculate(ConversionsModel data)
        {
            try
            {
                ConversionEnum coversionObj = new ConversionEnum();
                double value = (double)data.Value;
                string units = data.OperationType;
           
                switch (units)
                {
                    case "INCH":
                        return coversionObj.UnitConversion(Unit.INCH, value);
                    case "FEET":
                        return coversionObj.UnitConversion(Unit.FEET, value);
                    case "YARD":
                        return coversionObj.UnitConversion(Unit.YARD, value);
                    case "CM":
                        return coversionObj.UnitConversion(Unit.CM, value);
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
                    case "GALLON":
                        return coversionObj.UnitConversion(Unit.GALLON, value);
                    case "MILLILITER":
                        return coversionObj.UnitConversion(Unit.MILLILITER, value);
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
                    case "GRAMS":
                        return coversionObj.UnitConversion(Unit.GRAMS, value);
                    case "TONNE":
                        return coversionObj.UnitConversion(Unit.TONNE, value);
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
                    case "FAHRENHEIT":
                        return (value*1);
                    case "CELSIUS":
                        return (value*1);
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

        public CamparisonsModel AddComparison(CamparisonsModel Data)
        {
            try
            {
                Data.Result = Compare(Data);
                return this.measurmentRL.AddComparison(Data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private string Compare(CamparisonsModel data)
        {
            CamparisonsModel comparison = new CamparisonsModel();
            comparison.ValueOne = data.ValueOne;
            comparison.ValueOneUnit = data.ValueOneUnit;
            comparison.ValueTwo = data.ValueTwo;
            comparison.ValueTwoUnit = data.ValueTwoUnit;
            comparison.Result = data.Result;

            if ((comparison.ValueOneUnit.Equals(comparison.ValueTwoUnit)) && (comparison.ValueOne == comparison.ValueTwo))
            {
                return "Equals";
            }
            else
            {
                
                string unitOne = string.Concat(comparison.ValueOneUnit, "_TO_", comparison.ValueTwoUnit);
                string unitTwo = string.Concat(comparison.ValueTwoUnit);
                ConversionsModel ConversionOne = new ConversionsModel();
                ConversionsModel ConversionTwo = new ConversionsModel();
                ConversionOne.Value = comparison.ValueOne;
                ConversionOne.OperationType = unitOne;
                ConversionTwo.Value = comparison.ValueTwo;
                ConversionTwo.OperationType = unitTwo;
               
               
                decimal output = (decimal)Calculate(ConversionOne);
                decimal output2 = (decimal)Calculate(ConversionTwo);
                
                if (output == output2)
                {
                    return "equals";
                }
                else
                {
                    return "not equal";
                }
            }

        }

        public CamparisonsModel DeleteComparisone(int Id)
        {
            try
            {
                return this.measurmentRL.DeleteComparisone(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<CamparisonsModel> GetComparison()
        {
            try
            {
                return this.measurmentRL.GetComparison();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CamparisonsModel GetComparison(int Id)
        {
            try
            {
                return this.measurmentRL.GetComparison(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       
    }
}
