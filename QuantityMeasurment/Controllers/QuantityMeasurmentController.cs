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
        private IquantityMeasurmentBL MeasurmentBL;
        public QuantityMeasurmentController(IquantityMeasurmentBL MeasurmentBL)
        {
            this.MeasurmentBL = MeasurmentBL;
        }
        [HttpPost]
        [Route("conversion")]
        public IActionResult Convert(ConversionsModel Data)
        {
            try
            {
                if (Data == null)
                {
                  throw new  QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.NULL_VALUE_EXCEPTION , "Any field of data is null please enter value") ;
                }
                if (Data.Value <= 0 && !(Data.OperationType.Equals("FAHRENHEIT_TO_CELSIUS") || Data.OperationType.Equals("CELSIUS_TO_FAHRENHEIT")))
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.ZERO_OR_NEGATIVE_VALUE_EXCEPTION, "please enter non zero and positive value ");                  
                }
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
            catch(QuantityMeasurmentException e)
            {
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult  Delete([FromRoute] int Id)
        {
            try
            {
                ConversionsModel Data = MeasurmentBL.Delete(Id);
                if (Id <= 0)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.ZERO_OR_NEGATIVE_VALUE_EXCEPTION, "please enter non zero and positive id ");
                }
                if (Data != null)
                {
                    return Ok(new { success = true, Massage = "deletion is successful", data = Data });
                }
                else
                {
                    return Ok(new { success = true, Massage = "deletion is fail" });
                }
            }
            catch(QuantityMeasurmentException e)
            {
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllConversion()
        {
            try
            {
                IEnumerable<ConversionsModel> Data = MeasurmentBL.GetConversion();
                if (Data == null)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.NULL_VALUE_EXCEPTION, "nothing for get");
                }
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
                if (Data == null)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.NULL_VALUE_EXCEPTION, "id is not present or data is not present on this id");
                }
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
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
        [HttpPost]
        [Route("comparison")]
        public IActionResult AddComparison(CamparisonsModel Data)
        {
            try
            {
                if (Data == null)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.NULL_VALUE_EXCEPTION, "Any field of data is null please enter value");
                }
                if (Data.ValueOne <= 0 && Data.ValueTwo <= 0 && !(Data.ValueOneUnit.Equals("FAHRENHEIT") || Data.ValueTwoUnit.Equals("CELSIUS")))
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.ZERO_OR_NEGATIVE_VALUE_EXCEPTION, "please enter non zero and positive value ");
                }
                else if ((Data.ValueOne != 0) && (Data.ValueTwo != 0))
                {
                    Data = MeasurmentBL.AddComparison(Data);
                    return Ok(new { success = true, Massage = "conversion is successful", data = Data });
                }
                else
                {
                    return Ok(new { success = false, Massage = "conversion is fail", data = Data });
                }
            }
            catch (QuantityMeasurmentException e)
            {
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
       
       
        [HttpDelete("comparison/{Id}")]
        public IActionResult DeleteComparison([FromRoute] int Id)
        {
            try
            {
                CamparisonsModel Data = MeasurmentBL.DeleteComparisone(Id);
                if (Id <= 0)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.ZERO_OR_NEGATIVE_VALUE_EXCEPTION, "please enter non zero and positive id ");
                }
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
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
        [HttpGet]
        [Route("comparison")]
        public IActionResult GetAllComparison()
        {
            try
            {
                IEnumerable<CamparisonsModel> Data = MeasurmentBL.GetComparison();
                if (Data == null)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.NULL_VALUE_EXCEPTION, "id is not present or data is not present on this id");
                }
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
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }
       
       
        [HttpGet("comparison/{Id}")]
        public IActionResult GetComparisonById([FromRoute] int Id)
        {
            try
            {
                CamparisonsModel Data = MeasurmentBL.GetComparison(Id);
                if (Id <= 0)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.ZERO_OR_NEGATIVE_VALUE_EXCEPTION, "please enter a non zero and positive id");
                }
                if (Data == null)
                {
                    throw new QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType.NULL_VALUE_EXCEPTION, "nothing for get");
                }
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
                return BadRequest(new { success = false, Massage = e.Message });
            }
        }


    }
}
