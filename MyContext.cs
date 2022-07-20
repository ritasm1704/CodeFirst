using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace CodeFirst
{
    public class MyContext : DbContext
    {
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Inspector> Inspectors { get; set; }
        public DbSet<Remark> Remarks { get; set; }
        /*public MyContext() : base("InspectionsDataBase")
        {
            Database.SetInitializer(
                  new DropCreateDatabaseIfModelChanges<MyContext>());
        }*/

        public MyContext()
        {
            Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());
        }
        
    }
}
