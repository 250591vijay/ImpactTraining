using ImpactTraining.Data;
using ImpactTraining.Models.Exceldo_Model;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using OfficeOpenXml;

namespace ImpactTraining.Controllers.Excel
{
    public class ExceldoController : Controller
    {
        private readonly ApplicationContext _context;
        public ExceldoController(ApplicationContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            // _context database ko refer karega 
            // _context s database m jao aur customers naam k table to dhundo aur data variable m store kar do
            var data = _context.Customers.ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        //File ko jo receieve karenge wo IformFile class s karenge
        public IActionResult UploadFile(IFormFile file)
        {
            List<Customer> cst = new List<Customer>();
            try
            {
                if (file != null && file.Length > 0)
                {
                    // Excel pacakage to read or write karne k liye
                    using (var package = new ExcelPackage(file.OpenReadStream()))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        var worksheet = package.Workbook.Worksheets[0];
                        for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                        {
                            cst.Add(new Customer
                            {
                                Customer_Id = long.Parse(worksheet.Cells[row, 1].Text),
                                Account_No = long.Parse(worksheet.Cells[row, 2].Text),
                                Ifsc_Code = worksheet.Cells[row, 3].Text,
                                Account_Holder_Name = worksheet.Cells[row, 4].Text,
                                Check_No = long.Parse(worksheet.Cells[row, 5].Text),
                                MICR_Code = long.Parse(worksheet.Cells[row, 6].Text),
                                Is_Processed = Convert.ToBoolean(Convert.ToInt16(worksheet.Cells[row, 7].Text))
                            });
                        }
                    }
                }
                else
                {
                    return View(file);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            // jo excel file s data read kiya hai usko display karenge
            return View("DisplayFileData", cst);
        }
        [HttpGet]
        //Jo data excel file s aayega usko dikhana/display karna hoga uske liye ek create karenge DisplayFileData naam s
        public IActionResult DisplayFileData()
        {
            return View();
        }
        [HttpPost]
        // To save data in database index form view
        public IActionResult SaveFileData(List<Customer> customers)
        {
            var selectedData = customers.Where(e => e.Active == true).ToList();
            // To insert data into data base
            foreach (var customer in selectedData)
            {
                _context.Customers.Add(customer);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
