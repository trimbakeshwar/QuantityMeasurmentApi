using QuantityMeasurmentCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantityMeasurmentRL.interfaces
{
    public interface IquantityMeasurmentRL
    {
        ConversionModel GetQuantity(int Id);
        IEnumerable<ConversionModel> GetQuantities();
        ConversionModel Add(ConversionModel quantity);
        ConversionModel Delete(int Id);
    }
}
