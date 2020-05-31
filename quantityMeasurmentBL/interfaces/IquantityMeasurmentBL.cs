using QuantityMeasurmentCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace quantityMeasurmentBL.interfaces
{
    public interface IquantityMeasurmentBL
    {
        ConversionModel Convert(ConversionModel Data);
        ConversionModel Delete(int Id);
        IEnumerable<ConversionModel> GetConversion();
        ConversionModel GetConversion(int Id);

    }
}
