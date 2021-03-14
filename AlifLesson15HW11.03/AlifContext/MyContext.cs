using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AlifLesson15HW11._03.Models;
using Microsoft.EntityFrameworkCore;

namespace AlifLesson15HW11._03.AlifContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        { 
        }

        public MyContext()
        {
                
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
            )
        {
            optionsBuilder
                .UseSqlServer("Data source = DESKTOP-SS5TGJO\\SQLEXPRESS; initial catalog = Person1; Integrated security = true;");
        }

        internal Task FindAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
