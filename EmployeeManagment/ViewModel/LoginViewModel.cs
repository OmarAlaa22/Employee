using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Name Is Required")]
       public string Name { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }

    }
}
