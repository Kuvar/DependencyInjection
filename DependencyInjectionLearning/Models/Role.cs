using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DependencyInjectionLearning.Models
{
    public class Role
    {
        public Role()
        {
            this.Employees = new List<Employee>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }
        public string RoleType { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}