using System;
using System.Collections.Generic;
using System.Text;

namespace QuantityMeasurmentCL
{
    public class CamparisonModel
    {
        
        public int Id { get; set; }      
        public decimal ValueOne { get; set; }        
        public string ValueOneUnit { get; set; }        
        public decimal ValueTwo { get; set; }        
        public string ValueTwoUnit { get; set; }
        public string Result { get; set; }
    }
}
