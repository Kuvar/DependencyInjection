using DependencyInjectionLearning.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DependencyInjectionLearning.CF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("SoftvisionDB")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Employee>()
            .HasRequired<Role>(s => s.Role)
            .WithMany(g => g.Employees)
            .HasForeignKey<int>(s => s.RoleID);
        }
    }
}