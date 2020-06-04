using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quantityMeasurmentBL.interfaces;
using QuantityMeasurmentCL;
using QuantityMeasurmentCL.Exceptions;

namespace QuantityMeasurment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuantityMeasurmentController : ControllerBase
    {
        //create atribute of IquantityMeasurmentBL 
        private IquantityMeasurmentBL MeasurmentBL;
        //attribute initializze by constructor
        public QuantityMeasurmentController(IquantityMeasurmentBL MeasurmentBL)
        {
            this.MeasurmentBL = MeasurmentBL;
        }
        /// <summary>
        /// convert value into another unit
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        //when we send post request then conversion api call
        [HttpPost]
        [Route("conversion")]
        public IActionResult Convert(ConversionsModel Data)
        {
            try
            {
                //if data is null then throws exception any field od data is null 
                if (Data == null)
                {
                  throw new  QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.NULL_VALUE_EXCEPTION , "Any field of data is null please enter value") ;
                }
                //if value is -ve and not tempratur unit then throws exception value is -ve
                if (Data.Value <= 0 && !(Data.OperationType.Equals("FAHRENHEIT_TO_CELSIUS") || Data.OperationType.Equals("CELSIUS_TO_FAHRENHEIT")))
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.ZERO_OR_NEGATIVE_VALUE_EXCEPTION, "please enter non zero and positive value ");                  
                }
                //if data value is +ve then convertion take place and return ok
                else if (Data.Value !=0)
                {
                    Data=MeasurmentBL.Convert(Data);
                    return Ok(new { success = true, Massage = "conversion is successful", data = Data });
                }
                else
                {
                    
                    return Ok(new { success = false, Massage = "conversion is fail", data = Data });
                }
            }
            catch(Exception e)
            {
                //exception catch in this block and send bad request
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
        /// <summary>
        /// if id is match then delete record 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult  Delete([FromRoute] int Id)
        {
            try
            {
                //data related id is return in data variable and delete
                ConversionsModel Data = MeasurmentBL.Delete(Id);
                //if id is negative and zero then throws exception please enter positive id
                if (Id <= 0)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.ZERO_OR_NEGATIVE_VALUE_EXCEPTION, "please enter non zero and positive id ");
                }
                //if data is not null then send ok result if not success then return false result
                if (Data != null)
                {
                    return Ok(new { success = true, Massage = "deletion is successful", data = Data });
                }
                else
                {
                    return Ok(new { success = false, Massage = "deletion is fail" });
                }
            }
            catch(QuantityMeasurmentException e)
            {
                //exception is catch in this block and send badrequest error
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
        /// <summary>
        /// get all conversio from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllConversion()
        {
            try
            {
                //this function is return list of data is return and store in IEnumarable data
                IEnumerable<ConversionsModel> Data = MeasurmentBL.GetConversion();
                //if data is not null then send ok result if not success then return false result
                if (Data == null)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.NULL_VALUE_EXCEPTION, "nothing for get");
                }
                //if data is not null then send ok result if not success then return false result
                else if (Data != null)
                {
                    return Ok(new { success = true, Massage = "data fetch successful", data = Data });
                }
                else
                {
                    return Ok(new { success = true, Massage = "data fetch failed" });
                }
            }
            catch(QuantityMeasurmentException e)
            {
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
        [HttpGet("{Id}")]
        public IActionResult GetConversionById([FromRoute] int Id)
        {
            try
            {
                ConversionsModel Data = MeasurmentBL.GetConversion(Id);
                if(Id <= 0)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.ZERO_OR_NEGATIVE_VALUE_EXCEPTION, "please enter a non zero and positive id");
                }
                //if data is not null then send ok result if not success then return false result
                if (Data == null)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.NULL_VALUE_EXCEPTION, "id is not present or data is not present on this id");
                } 
                //if data is not null then send ok result if not success then return false result
                else if (Data != null)
                {
                    return Ok(new { success = true, Massage = "data fetch successful", data = Data });
                }
                else
                {
                    return Ok(new { success = true, Massage = "data fetch failed" });
                }
            }
            catch (QuantityMeasurmentException e)
            {
                //exception catch in this block and send bad request
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
        /// <summary>
        /// compare two values and return equal or not
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("comparison")]
        public IActionResult AddComparison(CamparisonsModel Data)
        {
            try
            {
                //if data is null return exception
                if (Data == null)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.NULL_VALUE_EXCEPTION, "Any field of data is null please enter value");
                }
                //if value 1 and value 2 is -ve or zero and not temperatur unit then return exception
                if (Data.ValueOne <= 0 && Data.ValueTwo <= 0 && !(Data.ValueOneUnit.Equals("FAHRENHEIT") || Data.ValueTwoUnit.Equals("CELSIUS")))
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.ZERO_OR_NEGATIVE_VALUE_EXCEPTION, "please enter non zero and positive value ");
                }
                //if value 1 and value 2 is not zero then return ok true otherwise return false
                else if ((Data.ValueOne != 0) && (Data.ValueTwo != 0))
                {
                    //after comparison done then return data 
                    Data = MeasurmentBL.AddComparison(Data);
                    return Ok(new { success = true, Massage = "conversion is successful", data = Data });
                }
                else
                {
                    return Ok(new { success = false, Massage = "conversion is fail", data = Data });
                }
            }
            catch (Exception e)
            {
                //exception catch in this block and send bad request
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
       
       /// <summary>
       /// if id match then delete data
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        [HttpDelete("comparison/{Id}")]
        public IActionResult DeleteComparison([FromRoute] int Id)
        {
            try
            {
                //idf id match then return deleted data
                CamparisonsModel Data = MeasurmentBL.DeleteComparisone(Id);
                //if id is -ve then throws exception
                if (Id <= 0)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.ZERO_OR_NEGATIVE_VALUE_EXCEPTION, "please enter non zero and positive id ");
                }
                //if data is not null then send ok result if not success then return false result
                if (Data != null)
                {
                    return Ok(new { success = true, Massage = "deletion is successful", data = Data });
                }
                else
                {
                    return Ok(new { success = true, Massage = "deletion is fail" });
                }
            }
            catch (QuantityMeasurmentException e)
            {
                //exception catch in this block and send bad request
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
        /// <summary>
        /// get all data from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("comparison")]
        public IActionResult GetAllComparison()
        {
            try
            {
                IEnumerable<CamparisonsModel> Data = MeasurmentBL.GetComparison();
                //if data is  null then throws excption
                if (Data == null)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.NULL_VALUE_EXCEPTION, "id is not present or data is not present on this id");
                }
                //if data is not null then send ok result if not success then return false result
                else if (Data != null)
                {
                    return Ok(new { success = true, Massage = "data fetch successful", data = Data });
                }
                else
                {
                    return Ok(new { success = true, Massage = "data fetch failed" });
                }
            }
            catch (QuantityMeasurmentException e)
            {
                //exception catch in this block and send bad request
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
       
       /// <summary>
       /// if id is match then return data
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        [HttpGet("comparison/{Id}")]
        public IActionResult GetComparisonById([FromRoute] int Id)
        {
            try
            {
               
                //if id is -ve then throws exception
                if (Id <= 0)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.ZERO_OR_NEGATIVE_VALUE_EXCEPTION, "please enter a non zero and positive id");
                }
                //if id is match comparison data return matching data 
                CamparisonsModel Data = MeasurmentBL.GetComparison(Id);
                //if data is  null then throws exception
                if (Data == null)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.NULL_VALUE_EXCEPTION, "nothing for get");
                }
                //if data is not null then send ok result if not success then return false result
                else if (Data != null)
                {
                    return Ok(new { success = true, Massage = "data fetch successful", data = Data });
                }
                else
                {
                    return Ok(new { success = true, Massage = "data fetch failed" });
                }
            }
            catch (QuantityMeasurmentException e)
            {
                //exception catch in this block and send bad request
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }


    }
}
