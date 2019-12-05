using Solution.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data
{
    public class MyContext:DbContext
    {
        public MyContext():base("name=MaChaine")
        {
        }

        //DbSet<> ...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // config + customConventions
            /*modelBuilder.Configurations.Add(.....);
            modelBuilder.Conventions.Add(....);*/
        }
    }
}
