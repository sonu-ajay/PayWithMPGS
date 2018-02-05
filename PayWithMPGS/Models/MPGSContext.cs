using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PayWithMPGS.Models
{
    public class MPGSContext : DbContext
    {
        public MPGSContext() : base("MPGSDBConnection")
        {
            Database.SetInitializer<MPGSContext>(new CreateDatabaseIfNotExists<MPGSContext>());
            Database.SetInitializer<MPGSContext>(new DropCreateDatabaseIfModelChanges<MPGSContext>());
        }

        public DbSet<MPGSPayment> MPGSPayments { get; set; }
    }
}