using CRUD_USING_ADO.DAL;
using CRUD_USING_ADO.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_USING_ADO.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly DataAccessDA _data;  //prasanna add this 

        public EmployeeController(DataAccessDA dd) {
            
            _data = dd;
        }



        public IActionResult Index()
        {
            var employee = _data.GetAllDat();
            return View(employee);
        }

        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee ee)
        {

            _data.Insert(ee);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = _data.GetElementById(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp1)
        {
            _data.update(emp1);
            return RedirectToAction("Index");
        }

        // 🔹 DELETE
        public IActionResult Delete(int id)
        {
            _data.delete(id);
            return RedirectToAction("Index");
        }


    }
}
