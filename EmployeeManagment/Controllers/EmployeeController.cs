using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Services.Interfaces;
using Services.UniteOfWork;
using System.Runtime.Intrinsics.X86;

namespace EmployeeManagment.Controllers
{
    [Authorize(Policy = "onlysee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IGovernorateRepository governorateRepository;
        private readonly ICityRepository cityRepository;
        private readonly IToastNotification toastNotification;

        public EmployeeController(IEmployeeRepository employeeRepository, IGovernorateRepository governorateRepository, ICityRepository cityRepository, IToastNotification toastNotification)
        {
            this.employeeRepository = employeeRepository;
            this.governorateRepository = governorateRepository;
            this.cityRepository = cityRepository;
            this.toastNotification = toastNotification;
            
        }

        [HttpGet]
        [Authorize(Policy = "crud")]
        public async Task<IActionResult> AddEmployee()
        {
            ViewBag.Governate = await governorateRepository.GetAll();
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "crud")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            if(ModelState.IsValid)
            {
                if(employee.Id==0)
                {
                    await employeeRepository.Insert(employee);
                   
                }
                else
                {
                    await employeeRepository.Update(employee);
                }
                if (await employeeRepository.Save() == 0)
                {
                    toastNotification.AddSuccessToastMessage("Saved Successfully");
                    return RedirectToAction("GetAllEmployee");
                }
            }
            ViewBag.Governate = await employeeRepository.GetAll();
            return View(employee);
        }
        [HttpGet]
        [Authorize(Policy = "onlysee")]
        public async Task< IActionResult> GetAllEmployee()
        {
         var Employess = await employeeRepository.GetAll(new[] { "Governorate","City", "center" });
          return View(Employess);
        }
        [HttpPost]
        public JsonResult SSNIsAlreadyExist(string SSN,int Id=0)
        {
            var employessn = employeeRepository.Find(x => x.SSN == SSN).FirstOrDefault();
            if (employessn != null)
            {
                if(Id == 0)
                {
                    return Json(false);
                }
                if (Id == employessn.Id)
                {
                    return Json(true);
                }
            }
           return Json(true);
        }

        [HttpPost]
        [Authorize(Policy = "crud")]
        public async Task< IActionResult> DeleteEmployee(int id)
        {
            var employee= await employeeRepository.Get(id);
            if (employee == null)
            {
                return BadRequest();
            }
           await employeeRepository.Remove(employee);
           return Ok();
        }

        [HttpGet]
        [Authorize(Policy = "crud")]
        public async Task< IActionResult> UpdateEmployee(int id)
        {
            ViewBag.Governate = await governorateRepository.GetAll();
            var employe = employeeRepository.findbyId(x => x.Id == id, new[]{"Governorate", "City", "center" });
            return View("AddEmployee",employe);
        }

        [HttpGet]
        public IActionResult AssessDenied()
        {
            return View();
        }

      
    }
 
  
}
