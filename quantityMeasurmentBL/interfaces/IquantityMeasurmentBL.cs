using QuantityMeasurmentCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace quantityMeasurmentBL.interfaces
{
    /// <summary>
    /// interface of busness layer and implement in quantitymeasurment bl
    /// </summary>
    public interface IquantityMeasurmentBL
    {
        ConversionsModel Convert(ConversionsModel Data);
        ConversionsModel Delete(int Id);
        IEnumerable<ConversionsModel> GetConversion();
        ConversionsModel GetConversion(int Id);
        CamparisonsModel AddComparison(CamparisonsModel quantity);
        CamparisonsModel DeleteComparisone(int Id);
        IEnumerable<CamparisonsModel> GetComparison();
        CamparisonsModel GetComparison(int Id);
    }
}
