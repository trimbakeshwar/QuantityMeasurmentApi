using QuantityMeasurmentCL;
using QuantityMeasurmentRL.DBContext;
using QuantityMeasurmentRL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantityMeasurmentRL.Services
{
    public class quantityMeasurmentRL : IquantityMeasurmentRL
    {
        private OperationDBContext dBContext;
        public quantityMeasurmentRL(OperationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public ConversionModel Add(ConversionModel data)
        {
            dBContext.Conversion.Add(data);
            dBContext.SaveChanges();
            return data;
        }

        public ConversionModel Delete(int Id)
        {
            ConversionModel Data = dBContext.Conversion.Find(Id);
            if(Data!=null)
            {
                dBContext.Conversion.Remove(Data);
                dBContext.SaveChanges();
            }
            return Data;

        }

        public IEnumerable<ConversionModel> GetConversion()
        {
            return dBContext.Conversion.ToList();
        }

        public ConversionModel GetConversion(int Id)
        {
            ConversionModel Data = dBContext.Conversion.Find(Id);
            return Data;
        }
    }
}
