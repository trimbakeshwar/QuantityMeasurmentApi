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
        public DbSet<ConversionModel> Quantities { get; set; }

        public DbSet<ConversionModel> Comparisons { get; set; }
    }
}
