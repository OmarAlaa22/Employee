using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        [MinLength(2),MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "State Is Required")]
        public string State { get; set; }
        [Required(ErrorMessage = "SSN Is Required")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "The number must be 14 digits.")]
        [Remote("SSNIsAlreadyExist", "Employee", HttpMethod = "POST", ErrorMessage = "SSN already exists", AdditionalFields = "Id")]
        public string SSN { get; set; }


        [Required(ErrorMessage ="Age Is Required")]
        [Range(20,40,ErrorMessage = "Enter the minimum age between 20 to 40")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender Is Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Salary Is Required")]
        public decimal Salary { get; set; }

        [ForeignKey(nameof(Governorate))]
        [Required(ErrorMessage = "Governorate Is Required")]

        public int GovernorateId { get; set; }
        public Governorate? Governorate { get; set; }

        [ForeignKey(nameof(center))]
        [Required(ErrorMessage = "Center Is Required")]
        public int centerId { get; set; }
  
        public Center? center { get; set; }

        [ForeignKey(nameof(City))]
        [Required(ErrorMessage = "Center Is Required")]
        public int CityId { get; set; }
       public City? City { get; set; }


    }
}
