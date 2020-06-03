using System;
using System.Collections.Generic;
using System.Text;

namespace QuantityMeasurmentCL.Exceptions
{
    public class QuantityMeasurmentException : Exception
    {
        public enum ExceptionType
        {
            NOT_VALID_TYPE,
            NULL_VALUE_EXCEPTION,
            ZERO_OR_NEGATIVE_VALUE_EXCEPTION
        }
        public ExceptionType type;
        public QuantityMeasurmentException(QuantityMeasurmentException.ExceptionType type , string message) : base(message)
        {
            this.type = type;
        }
    }
}
