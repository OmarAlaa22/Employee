using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Repository;

namespace EmployeeManagment.Controllers
{
    public class CenterController : Controller
    {
        private readonly ICenterRepository centerRepository;

        public CenterController(ICenterRepository centerRepository)
        {
            this.centerRepository = centerRepository;
        }
        [HttpPost]
        public IActionResult GetCenters([FromBody] int cityid)
        {
            var centers = centerRepository.Find(x => x.CityId == cityid);
            return Ok(centers);
        }

    }
}
