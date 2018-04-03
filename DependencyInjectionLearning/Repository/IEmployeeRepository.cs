using DependencyInjectionLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionLearning.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
        Employee Add(Employee item);
        bool Update(Employee item);
        bool Delete(int id);
    }
}
