﻿using System;
using System.Collections.Generic;
using System.Text;
using static QuantityMeasurmentCL.ConversionEnum;

namespace QuantityMeasurmentCL
{
    public class ConversionModel
    {

       
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string OperationType { get; set; }
        public decimal Result { get; set; }
    }
}
