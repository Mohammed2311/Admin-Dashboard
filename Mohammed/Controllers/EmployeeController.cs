using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mohammed.BL.Interface;
using Mohammed.BL.Models;
using Mohammed.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{

    #region Visual Studio Implementation 
    //    // GET: Employee
    //    public async Task<IActionResult> Index()
    //    {
    //        var moContext = _context.Employees.Include(e => e.Department);
    //        return View(await moContext.ToListAsync());
    //    }

    //    // GET: Employee/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var employee = await _context.Employees
    //            .Include(e => e.Department)
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (employee == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(employee);
    //    }

    //    // GET: Employee/Create
    //    public IActionResult Create()
    //    {
    //        ViewData["DepartmentId"] = new SelectList(_context.Departments, "ID", "ID");
    //        return View();
    //    }

    //    // POST: Employee/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("Id,Name,Salary,HireDate,IsActive,Notes,Email,DepartmentId,IsDleted")] Employee employee)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(employee);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["DepartmentId"] = new SelectList(_context.Departments, "ID", "ID", employee.DepartmentId);
    //        return View(employee);
    //    }

    //    // GET: Employee/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var employee = await _context.Employees.FindAsync(id);
    //        if (employee == null)
    //        {
    //            return NotFound();
    //        }
    //        ViewData["DepartmentId"] = new SelectList(_context.Departments, "ID", "ID", employee.DepartmentId);
    //        return View(employee);
    //    }

    //    // POST: Employee/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Salary,HireDate,IsActive,Notes,Email,DepartmentId,IsDleted")] Employee employee)
    //    {
    //        if (id != employee.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(employee);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!EmployeeExists(employee.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["DepartmentId"] = new SelectList(_context.Departments, "ID", "ID", employee.DepartmentId);
    //        return View(employee);
    //    }

    //    // GET: Employee/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var employee = await _context.Employees
    //            .Include(e => e.Department)
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (employee == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(employee);
    //    }

    //    // POST: Employee/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var employee = await _context.Employees.FindAsync(id);
    //        _context.Employees.Remove(employee);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool EmployeeExists(int id)
    //    {
    //        return _context.Employees.Any(e => e.Id == id);
    //    }
    //} 
    #endregion

    public class EmployeeController : Controller
    {
        private readonly IEmployeeRep employee;
        private readonly IMapper mapper;
        private readonly IDepartmentRep department;
        private readonly IDistricRep distric;
        private readonly ICityRep city;

        public EmployeeController( IEmployeeRep employee , IMapper mapper , IDepartmentRep department , IDistricRep distric , ICityRep city)
        {
            this.employee = employee;
            this.mapper = mapper;
            this.department = department;
            this.distric = distric;
            this.city = city;
        }
        [HttpPost]
        public async Task<JsonResult> search(string SearchValue= "")
        {
            try
            {
                if (SearchValue == "")
                {
                    var data = await employee.GetAll();
                    var model = mapper.Map<IEnumerable<EmployeeVm>>(data);
                    return Json(model);
                }
                else
                {
                    var data = await employee.Search(SearchValue);
                    var model = mapper.Map<IEnumerable<EmployeeVm>>(data);
                    return Json(model);
                }
            }
            catch (Exception ex )
            {

                ViewBag.x = ex.Message;
                return Json(ViewBag.x);
            }
            
        }
        public async Task<IActionResult> Index()
        {
            
                var data = await employee.GetAll();
                var model = mapper.Map<IEnumerable<EmployeeVm>>(data);
                return View(model);
            
           
           
        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(EmployeeVm model)
        //{

        //    try
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            var data = mapper.Map<Employee>(model);
        //            employee.Create(data);
        //            return RedirectToAction("Index");
        //        }


        //        ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");
        //        return View(model);
        //    }
        //}


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVm employeeVm)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(employeeVm);
                    await employee.Create(data);
                    return RedirectToAction("index");
                }
                else
                {
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.x = ex;
              return  View(employeeVm);
            }
        }
        #region create 
        //public async Task<IActionResult> Create(EmployeeVm employeeVm)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var data = mapper.Map<Employee>(employeeVm);
        //            await employee.Create(data);
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {

        //            return View(employeeVm);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.x = ex;
        //        ViewBag.y = ex.Data;
        //        return View(employeeVm);
        //    }

        //} 
        #endregion

        [HttpGet]
        public async Task< IActionResult> Edit(int id)
        {
            var data =await employee.GetById(id);
            var model = mapper.Map<EmployeeVm>(data);
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);
            return View(model);
           
        }

        [HttpPost]
        public async Task< IActionResult> Edit(EmployeeVm model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    await employee.Edit(data);
                    return RedirectToAction("Index");
                }


              ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);
                return View(model);
            }
            catch (Exception ex)
            {

                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);
                return View(model);
            }
        }

        #region Ajax
        [HttpPost]
        public async Task<JsonResult> GetCityDataByCountryId(int CtryId)
        {
            var data = await city.Get(c => c.CountryId == CtryId);
            var model = mapper.Map<IEnumerable<CityVm>>(data);
            return Json(model);
        }

        [HttpPost]
        public async Task<JsonResult> GetDistrictDataByCityId(int CtyId)
        {
            var data =await distric.Get(a => a.CityID == CtyId);
            var model = mapper.Map<IEnumerable<DistricVm>>(data);
            return Json(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<JsonResult> Search(string SearchValue = "")
        {
            try
            {
                if (SearchValue == "")
                {
                    var data = await employee.GetAll();
                    var model = mapper.Map<IEnumerable<EmployeeVm>>(data);
                    return Json(model);
                }
                else
                {
                    var data = await employee.Search(SearchValue);
                    var model = mapper.Map<IEnumerable<EmployeeVm>>(data);
                    return Json(model);
                }
            }
            catch (Exception ex)
            {

                ViewBag.x = ex.Message;
                return Json(ViewBag.x);
            }

        }

        [HttpPost]

        public JsonResult GetData(string name)
        {
            var data = "Welcome " + name;
            return Json(data);
        }
        #endregion



    }
}
