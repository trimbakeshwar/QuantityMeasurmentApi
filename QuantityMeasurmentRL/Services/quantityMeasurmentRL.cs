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
        private OperationsDBContext dBContext;
        public quantityMeasurmentRL(OperationsDBContext dBContext)
        {
            
            this.dBContext = dBContext;
        }
        public ConversionsModel Add(ConversionsModel data)
        {
            try 
            {
                dBContext.Conversions.Add(data);
                dBContext.SaveChanges();
                return data;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public CamparisonsModel AddComparison(CamparisonsModel data)
        {
            try
            {
                dBContext.Comparisons.Add(data);
                dBContext.SaveChanges();
                return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ConversionsModel Delete(int Id)
        {
            try
            {
                ConversionsModel Data = dBContext.Conversions.Find(Id);
                if (Data != null)
                {
                    dBContext.Conversions.Remove(Data);
                    dBContext.SaveChanges();
                }
                return Data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        public CamparisonsModel DeleteComparisone(int Id)
        {
            try
            {
                CamparisonsModel Data = dBContext.Comparisons.Find(Id);
                if (Data != null)
                {
                    dBContext.Comparisons.Remove(Data);
                    dBContext.SaveChanges();
                }
                return Data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<CamparisonsModel> GetComparison()
        {
            try
            {
                return dBContext.Comparisons.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CamparisonsModel GetComparison(int Id)
        {
            try
            {
                CamparisonsModel Data = dBContext.Comparisons.Find(Id);
                return Data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<ConversionsModel> GetConversion()
        {
            try
            { 
                return dBContext.Conversions.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public ConversionsModel GetConversion(int Id)
        {
            try
            {
                ConversionsModel Data = dBContext.Conversions.Find(Id);
                return Data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }           
    }
}
