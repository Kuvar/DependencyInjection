using DependencyInjectionLearning.CF;
using DependencyInjectionLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjectionLearning.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly DatabaseContext db;
        public EmployeeRepository()
        {
            db = new DatabaseContext();
        }

        public Employee Add(Employee item)
        {
            if (item != null)
            {
              var emp =  db.Employees.Add(item);
                db.SaveChanges();
                return emp;
            }
            return item;
        }

        public bool Delete(int id)
        {
            var emp = Get(id);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return true;
        }

        public Employee Get(int id)
        {
            return db.Employees.FirstOrDefault(c => c.EmployeeID == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees;
        }

        public bool Update(Employee item)
        {
            var emp = Get(item.EmployeeID);
            emp.Name = item.Name;
            emp.Mobile = item.Mobile;
            emp.Email = item.Email;
            emp.RoleID = item.RoleID;
            db.SaveChanges();
            return true;
        }
    }
}