using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Real_Time_Commenting.Models
{
    public class CaseDbContext:DbContext
    {
        public CaseDbContext() : base("Cases")
        {

        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Priotrity> Priorities { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}