using DependencyInjectionLearning.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DependencyInjectionLearning.CF
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext> //CreateDatabaseIfNotExists 
    {
        protected override void Seed(DatabaseContext context)
        {

            var roles = new List<Role>()
            {
                new Role{RoleType ="Admin"},
                new Role{RoleType = "User"}
            };
            roles.ForEach(x => context.Roles.Add(x));

            context.SaveChanges();

            var employees = new List<Employee>()
            {
                new Employee{Name = "Pankaj Singh", Mobile = "7827844474", Email="kuvarjava@gmailcom", RoleID=1},
                new Employee{Name = "Rishab", Mobile = "9716441004", Email = "rishab1993@gmail.com", RoleID=2}
            };
            employees.ForEach(x => context.Employees.Add(x));

           

            var companies = new List<Company>()
            {
                new Company { Name = "Softvision", Category = "Software" },
                new Company { Name = "Infosys", Category = "Software" },
                new Company { Name = "Accenture", Category = "Software" },
                new Company { Name = "NTT DATA", Category = "Software" },
                new Company { Name = "TCS", Category = "Software" },
                new Company { Name = "Wipro", Category = "Software" }
            };
            companies.ForEach(x => context.Companies.Add(x));

            context.SaveChanges();
        }
    }
}