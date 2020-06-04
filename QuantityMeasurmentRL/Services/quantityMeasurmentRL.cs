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
        //create attribute of db context and intialize in constructor
        private OperationsDBContext dBContext;

        public quantityMeasurmentRL()
        {
        }

        public quantityMeasurmentRL(OperationsDBContext dBContext)
        {
            
            this.dBContext = dBContext;
        }
        /// <summary>
        /// add data in database 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ConversionsModel Add(ConversionsModel data)
        {
            try 
            {//add data in conversions table by using dbcontext
                dBContext.Conversions.Add(data);
                //exicute this quri by dbcontext
                dBContext.SaveChanges();
                //return data we was added  in database
                return data;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
        /// <summary>
        /// add comparisons in comparisons table
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public CamparisonsModel AddComparison(CamparisonsModel data)
        {
            try
            {
                // add data in comparisons table by using dbcontext
                dBContext.Comparisons.Add(data);
                // exicute this quri by dbcontext
                dBContext.SaveChanges();
                //return data we was added  in database
                return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// delete data by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ConversionsModel Delete(int Id)
        {
            try
            {
                //first find the record match to the id  then return data related id
                ConversionsModel Data = dBContext.Conversions.Find(Id);
                //if id not null then remove this data and exicute quries
                if (Data != null)
                {
                    dBContext.Conversions.Remove(Data);
                    dBContext.SaveChanges();
                }
                //return data related id
                return Data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }
        /// <summary>
        /// delete related id comparisons
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CamparisonsModel DeleteComparisone(int Id)
        {
            try
            {

                //first find the record match to the id  then return data related id
                CamparisonsModel Data = dBContext.Comparisons.Find(Id);
                //if id not null then remove this data and exicute quries
                if (Data != null)
                {
                    dBContext.Comparisons.Remove(Data);
                    dBContext.SaveChanges();
                }
                //return data related id
                return Data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// get all data from comparisons table
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// get all comparisons related id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CamparisonsModel GetComparison(int Id)
        {
            try
            {
                //first find id and return related data
                CamparisonsModel Data = dBContext.Comparisons.Find(Id);
                return Data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// get all data from conversion
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// get conversion by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ConversionsModel GetConversion(int Id)
        {
            try
            {
                 //first find id and return related data
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
