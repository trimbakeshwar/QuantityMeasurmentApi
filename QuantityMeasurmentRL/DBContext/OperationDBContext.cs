using Microsoft.EntityFrameworkCore;
using QuantityMeasurmentCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuantityMeasurmentRL.DBContext
{
    public class OperationsDBContext : DbContext
    {
        public OperationsDBContext(DbContextOptions<OperationsDBContext> options) : base(options)
        {

        }
        public DbSet<ConversionsModel> Conversions { get; set; }

        public DbSet<CamparisonsModel> Comparisons { get; set; }
    }
}
