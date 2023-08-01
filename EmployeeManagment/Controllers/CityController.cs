using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace EmployeeManagment.Controllers
{
    public class CityController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IGovernorateRepository governorateRepository;
        private readonly ICityRepository cityRepository;


        public CityController(IEmployeeRepository employeeRepository, IGovernorateRepository governorateRepository, ICityRepository cityRepository)
        {
            this.employeeRepository = employeeRepository;
            this.governorateRepository = governorateRepository;
            this.cityRepository = cityRepository;
        }
        [HttpPost]
        public IActionResult GetCities([FromBody] int governateid)
        {
            var cities = cityRepository.Find(x => x.GovernateId == governateid);
            return Ok(cities);
        }

    }
}
