using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mohammed.DAL.Entity;


namespace Mohammed.DAL.DataBase
{
    public class MoContext:DbContext
    {
        public MoContext(DbContextOptions<MoContext> context):base(context)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet <Employee> Employees { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country>Countries { get; set; }
        public DbSet<Distric>Districs { get; set; }

    }
}
