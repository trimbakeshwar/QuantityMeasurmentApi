using quantityMeasurmentBL.interfaces;
using QuantityMeasurmentCL;
using QuantityMeasurmentRL.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static QuantityMeasurmentCL.ConversionEnum;

namespace quantityMeasurmentBL.Services
{
    /// <summary>
    /// all business logic are write heare
    /// </summary>
    public class quantitymeasurmentBL : IquantityMeasurmentBL
    {//create attributes of repository layer and send dependancy to constructor
        private IquantityMeasurmentRL measurmentRL;
        //initialize repository layer in constructor
        public quantitymeasurmentBL(IquantityMeasurmentRL measurmentRL)
        {
            this.measurmentRL = measurmentRL;
        }
        /// <summary>
        /// convert value one unit to other unit
        /// </summary>
        /// <param name="Data">value and unit for conversion</param>
        /// <returns></returns>
        public ConversionsModel Convert(ConversionsModel Data)
        {
            try
            {
                //call the calculate method for calculation
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
                //create object of struct class 
                ConversionEnum coversionObj = new ConversionEnum();
                //give the value to value variable and unit 
                double value = (double)data.Value;
                string units = data.OperationType;
                //unit string compare in below cases if match then convert into this other unit then return converted data
                //if not matching below cases then return exception
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
        /// <summary>
        /// delete particular data when matching id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ConversionsModel Delete(int Id)
        {
            try
            {
                //it calles the delete method in repository class
                return this.measurmentRL.Delete(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// return all conversion from database
        /// </summary>
        /// <returns></returns>

        public IEnumerable<ConversionsModel> GetConversion()
        {
            try 
            {
                //it calles the get method in repository class
                return this.measurmentRL.GetConversion();
            }
             catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// get conversion by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ConversionsModel GetConversion(int Id)
        {
            try
            {
                //it calles the get by id method in repository class
                return this.measurmentRL.GetConversion(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// compare two value and return equal or not
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>

        public CamparisonsModel AddComparison(CamparisonsModel Data)
        {
            try
            {
                //it call compare method and return equal or not
                Data.Result = Compare(Data);
                //call to add methode to add data in database
                return this.measurmentRL.AddComparison(Data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// compare two value and return equal or not
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Compare(CamparisonsModel data)
        {
            CamparisonsModel comparison = new CamparisonsModel();
            comparison.ValueOne = data.ValueOne;
            comparison.ValueOneUnit = data.ValueOneUnit;
            comparison.ValueTwo = data.ValueTwo;
            comparison.ValueTwoUnit = data.ValueTwoUnit;
            comparison.Result = data.Result;
            //if unit is same and value is same then return equal 
            if ((comparison.ValueOneUnit.Equals(comparison.ValueTwoUnit)) && (comparison.ValueOne == comparison.ValueTwo))
            {
                return "Equals";
            }
            //otherwise convert into same unit and compare data if same then return equal otherwise return false
            else
            {
                //concat the two unit and create converted unit
                string unitOne = string.Concat(comparison.ValueOneUnit, "_TO_", comparison.ValueTwoUnit);
                string unitTwo = string.Concat(comparison.ValueTwoUnit);
                //for conversion create object and gives value to model and convert it by calling calculate method
                ConversionsModel ConversionOne = new ConversionsModel();
                ConversionsModel ConversionTwo = new ConversionsModel();
                ConversionOne.Value = comparison.ValueOne;
                ConversionOne.OperationType = unitOne;
                ConversionTwo.Value = comparison.ValueTwo;
                ConversionTwo.OperationType = unitTwo;
               
               //data is return in output variable
                decimal output = (decimal)Calculate(ConversionOne);
                decimal outputTwo = (decimal)Calculate(ConversionTwo);
                //if both match then return equal otherwise return not equal
                if (output == outputTwo)
                {
                    return "equals";
                }
                else
                {
                    return "not equal";
                }
            }

        }
        /// <summary>
        /// delete comparison by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CamparisonsModel DeleteComparisone(int Id)
        {
            try
            {
                //on the basis of dependancy injection is call the method and delete this id
                return this.measurmentRL.DeleteComparisone(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// get all comparison from comparison table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CamparisonsModel> GetComparison()
        {
            try
            {
                //on the basis of dependancy injection is call the method and get all data 
                return this.measurmentRL.GetComparison();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// get data when id match 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CamparisonsModel GetComparison(int Id)
        {
            try
            {
                //on the basis of dependancy injection is call the method and get this id data
                return this.measurmentRL.GetComparison(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       
    }
}
