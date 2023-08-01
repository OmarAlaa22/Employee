using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class EmployeeList
    {
        public int Id { get; set; }

       public string Name { get; set; }

        public string State { get; set; }

        public string SSN { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public decimal Salary { get; set; }
         public string GovernorateName { get; set; }
        public string CenterName { get; set; }


        public string CityName { get; set; }
    }
}
