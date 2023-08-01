using AspNetCore.Reporting;
using Domain.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly EmployeeDbContext employeeDbContext;

        public ReportController(IWebHostEnvironment webHostEnvironment, EmployeeDbContext employeeDbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.employeeDbContext = employeeDbContext;
        }
        public IActionResult Index()
        {
           
            return View();
        }
        public FileContentResult DownloadReport()
        {
            string format = "PDF";
            string extinission = "pdf";
            string mimetype = "application/pdf";
            string reportpath = $"{webHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";
            var data = employeeDbContext.GetAllEmployee();
            var datatable = HelperClass.ToDataTable(data);
            var localreport = new LocalReport(reportpath);
            localreport.AddDataSource("DataSet1", datatable);
            var result = localreport.Execute(RenderType.Pdf, 1, null, mimetype);
            return File(result.MainStream, mimetype);
        }
    }
}
