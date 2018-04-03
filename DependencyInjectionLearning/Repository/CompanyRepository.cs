using DependencyInjectionLearning.CF;
using DependencyInjectionLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjectionLearning.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly DatabaseContext db;

        public CompanyRepository()
        {
            db = new DatabaseContext();
        }

        public IEnumerable<Company> GetAll()
        {
            return db.Companies;
        }
        public Company Get(int id)
        {
            // TO DO : Code to find a record in database  
            return db.Companies.FirstOrDefault(c => c.Id == id);
        }
        public Company Add(Company item)
        {
            if (item != null)
            {
               var comp =  db.Companies.Add(item);
                db.SaveChanges();
                return comp;
            }

            return item;
        }
        public bool Update(Company item)
        { 
            var comp = Get(item.Id);
            comp.Name = item.Name;
            comp.Category = item.Category;

            if (db.SaveChanges() > 0)
                return true;
            else
                return true;
        }
        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database  
            var comp = Get(id);
            db.Companies.Remove(comp);
            if (db.SaveChanges() > 0)
                return true;
            else
                return true;
        }
    }
}