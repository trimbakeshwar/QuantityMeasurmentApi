﻿using QuantityMeasurmentCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantityMeasurmentRL.interfaces
{
    public interface IquantityMeasurmentRL
    {
            
        ConversionsModel Add(ConversionsModel quantity);
        ConversionsModel Delete(int Id);
        IEnumerable<ConversionsModel> GetConversion();
        ConversionsModel GetConversion(int Id);
        CamparisonsModel AddComparison(CamparisonsModel quantity);
        CamparisonsModel DeleteComparisone(int Id);
        IEnumerable<CamparisonsModel> GetComparison();
        CamparisonsModel GetComparison(int Id);

    }
}
