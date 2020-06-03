
using Microsoft.AspNetCore.Mvc;
using Moq;
using QuantityMeasurment.Controllers;
using quantityMeasurmentBL.interfaces;
using quantityMeasurmentBL.Services;
using QuantityMeasurmentCL;
using QuantityMeasurmentCL.Exceptions;
using QuantityMeasurmentRL.interfaces;
using QuantityMeasurmentRL.Services;
using System;
using Xunit;

namespace QuantityMeasurmentTest
{
    public class UnitTest1
    {
        
        QuantityMeasurmentController controller;
       
        private readonly Mock<IquantityMeasurmentBL> mock;
       
        public UnitTest1()
        {
            mock = new Mock<IquantityMeasurmentBL>();
            controller = new QuantityMeasurmentController(mock.Object);
        }

        [Fact]
        public void When_GetAllConversion_Called_Then_ReturnOkResult()
        {
            var OkResult = controller.GetAllConversion();
            Assert.IsType<OkObjectResult>(OkResult);


        }

        [Fact]
        public void When_gives_wrong_GetConversionById_Called_Then_ReturnOkResul()
        {
            //Calling The GetQuantites Function.
            var OkResult = controller.GetConversionById(88);

            //Asserting Values.
            Assert.IsType<BadRequestObjectResult>(OkResult);
        }
        [Fact]
        public void When_GetAllComparison_Called_Then_ReturnOkResult()
        {
            //Calling The GetQuantites Function.
            var OkResult = controller.GetAllComparison();

            //Asserting Values.
            Assert.IsType<OkObjectResult>(OkResult);
        }
        [Fact]
        public void When_gives_wrong_GetComparisonById_Called_Then_BadRequestObjectResult()
        {
            //Calling The GetQuantites Function.
            var OkResult = controller.GetComparisonById(15);

            //Asserting Values.
            Assert.IsType<BadRequestObjectResult>(OkResult);
        }
        [Fact]
        public void when_gives_conversion_object_then_return_okResult()
        {
            //Creating Model Object.
            var data = new ConversionsModel()
            {
                Value = 10,
                OperationType = "INCH_TO_FEET"
            };

           

            //Calling Convert Funtion.
            var badResponse = controller.Convert(data);

            //Asserting Values.
            Assert.IsType<OkObjectResult>(badResponse);
        }
        [Fact]
        public void when_gives_Wrong_conversion_object_then_return_BadRequestObjectResult()
        {
            //Creating Model Object.
            var data = new ConversionsModel()
            {
                Value = 0,
                OperationType = "INCH_TO_FEET"
            };



            //Calling Convert Funtion.
            var badResponse = controller.Convert(data);

            //Asserting Values.
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public void when_gives_null_conversion_object_then_return_BadRequestObjectResult()
        {
            //Creating Model Object.
            var data = new ConversionsModel()
            {
                Value = -21,
                OperationType = "INCH_TO_FEET"
            };



            //Calling Convert Funtion.
            var badResponse = controller.Convert(data);

            //Asserting Values.
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public void when_gives_wrong_datatype_object_then_return_BadRequestObjectResult()
        {
            //Creating Model Object.
            var data = new ConversionsModel()
            {
                Value = -21,
                OperationType = "INCH_TO_CM"
            };



            //Calling Convert Funtion.
            var badResponse = controller.Convert(data);

            //Asserting Values.
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public void when_gives_Comparison_object_then_return_okResult()
        {
            //Creating Model Object.
            var data = new CamparisonsModel()
            {
                ValueOne = 1,
                ValueOneUnit = "FEET",
                ValueTwo = 12,
                ValueTwoUnit = "INCH"
            };
            controller.ModelState.AddModelError("OperationType", "Required");
            //Calling Convert Funtion.
            var okReasult = controller.AddComparison(data);

            //Asserting Values.
            Assert.IsType<OkObjectResult>(okReasult);
        }
        [Fact]
        public void when_gives_zero_Comparison_object_then_return_BadRequestObjectResult()
        {
            //Creating Model Object.
            var data = new CamparisonsModel()
            {
                ValueOne = 0,
                ValueOneUnit = "FEET",
                ValueTwo = 0,
                ValueTwoUnit = "INCH"
            };
            controller.ModelState.AddModelError("OperationType", "Required");
            //Calling Convert Funtion.
            var okReasult = controller.AddComparison(data);

            //Asserting Values.
            Assert.IsType<BadRequestObjectResult>(okReasult);
        }
        [Fact]
        public void when_gives_negative_Comparison_object_then_return_BadRequestObjectResult()
        {
            //Creating Model Object.
            var data = new CamparisonsModel()
            {
                ValueOne = -12,
                ValueOneUnit = "FEET",
                ValueTwo = -11,
                ValueTwoUnit = "INCH"
            };
            controller.ModelState.AddModelError("OperationType", "Required");
            //Calling Convert Funtion.
            var okReasult = controller.AddComparison(data);

            //Asserting Values.
            Assert.IsType<BadRequestObjectResult>(okReasult);
        }
        [Fact]
        public void when_gives_negative_temperature_Comparison_object_then_return_okResult()
        {
            //Creating Model Object.
            var data = new CamparisonsModel()
            {
                ValueOne = -12,
                ValueOneUnit = "FAHRENHEIT",
                ValueTwo = -11,
                ValueTwoUnit = "CELSIUS"
            };
            controller.ModelState.AddModelError("OperationType", "Required");
            //Calling Convert Funtion.
            var okReasult = controller.AddComparison(data);

            //Asserting Values.
            Assert.IsType<OkObjectResult>(okReasult);
        }


        [Fact]
        public void Deleting_conversionById_ShouldReturnOkResult()
        {
            //Calling Delete Function.
            var OkResult = controller.Delete(5);

            //Asserting Values.
            Assert.IsType<OkObjectResult>(OkResult);
        }

        /// <summary>
        /// Test Case For Delete Function With Invalid Id.
        /// </summary>
        [Fact]
        public void Deleting_conversion_ByInvalidId_Should_ReturnBadRequest()
        {
            //Calling Delete Function.
            var Result = controller.Delete(-19);

            //Asserting Values.
            Assert.IsType<BadRequestObjectResult>(Result);
        }

        /// <summary>
        /// Test Case For GetComparisons Function.
        /// </summary>
      

        /// <summary>
        /// Test Case For GetComparison Function With Invalid Id.
        /// </summary>
        [Fact]
        public void WhenGetComparison_With_InvalidId_Called_ShouldReturnBadRequest()
        {
            //Calling GetComparison to Get Specific Comparison Details.
            var Result = controller.GetComparisonById(-22);

            //Assserting Values.
            Assert.IsType<BadRequestObjectResult>(Result);
        }

        /// <summary>
        /// Test CAse For Compare Function With Invalid Data.
        /// </summary>
       

        /// <summary>
        /// Test Case For DeleteComparison Function.
        /// </summary>
        [Fact]
        public void WheneDeleteComparisonCalledShouldReturnOkResul()
        {
            //Calling DeleteComparison Function.
            var OkResult = controller.DeleteComparison(6);

            //Asserting Values.
            Assert.IsType<OkObjectResult>(OkResult);
        }

        /// <summary>
        /// Test Case For DeleteComparison Function With Invalid Id.
        /// </summary>
        [Fact]
        public void WheneDeleteComparisonCalledWithInvalidIdShouldReturnBadRequest()
        {
            //Calling DeleteComparison Function.
            var Result = controller.DeleteComparison(-25);

            //Asserting Values.
            Assert.IsType<BadRequestObjectResult>(Result);
        }
    }
}
