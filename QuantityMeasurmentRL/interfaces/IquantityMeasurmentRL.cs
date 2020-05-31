using QuantityMeasurmentCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantityMeasurmentRL.interfaces
{
    public interface IquantityMeasurmentRL
    {
            
        ConversionModel Add(ConversionModel quantity);
        ConversionModel Delete(int Id);
        IEnumerable<ConversionModel> GetConversion();
        ConversionModel GetConversion(int Id);
    }
}
