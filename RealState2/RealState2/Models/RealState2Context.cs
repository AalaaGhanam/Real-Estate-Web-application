using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealState2.Models
{
    public class RealState2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RealState2Context() : base("name=RealState2Context")
        {
            Database.SetInitializer<RealState2Context>(new DropCreateDatabaseIfModelChanges<RealState2Context>());
        }

        public System.Data.Entity.DbSet<RealState2.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<RealState2.Models.Project> Projects { get; set; }
        public System.Data.Entity.DbSet<RealState2.Models.TwoModel> TwoModels { get; set; }
    }
}
