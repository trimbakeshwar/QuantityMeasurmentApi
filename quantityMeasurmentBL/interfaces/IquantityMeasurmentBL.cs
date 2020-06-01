using QuantityMeasurmentCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace quantityMeasurmentBL.interfaces
{
    public interface IquantityMeasurmentBL
    {
        ConversionsModel Convert(ConversionsModel Data);
        ConversionsModel Delete(int Id);
        IEnumerable<ConversionsModel> GetConversion();
        ConversionsModel GetConversion(int Id);

    }
}
