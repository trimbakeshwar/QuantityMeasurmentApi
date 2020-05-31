using Microsoft.EntityFrameworkCore;
using QuantityMeasurmentCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantityMeasurmentRL.DBContext
{
    public class OperationDBContext : DbContext
    {
        OperationDBContext(DbContextOptions<OperationDBContext> options) : base(options)
        {

        }
        public DbSet<ConversionModel> Conversion { get; set; }

        public DbSet<CamparisonModel> Comparisons { get; set; }
    }
}
