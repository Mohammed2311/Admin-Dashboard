using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Mohammed.BL.Models;
using Mohammed.BL.Interface;
using AutoMapper;
using Mohammed.DAL.Entity;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRep department;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentRep department , IMapper mapper)
        {
            this.department = department;
            this.mapper = mapper;
        }
        #region Actions
        public async Task<IActionResult> Index(string searchVal = "")
        {
            if (searchVal == "")
            {
                var data = await department.GetAll();
                var model = mapper.Map<IEnumerable<DepartmentVm>>(data);
                return View(model);
            }
            else
            {
                var data = await department.Search(searchVal);
                var model = mapper.Map<IEnumerable<DepartmentVm>>(data);
                return View(model);
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data =await department.GetById(id);
            var mm = mapper.Map<DepartmentVm>(data);
            return View(mm);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(DepartmentVm model)
        {

            try
            {
                var data = mapper.Map<Department>(model);
                if (ModelState.IsValid)
                {
                   await department.Create(data);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            var dept =await department.GetById(id);
            var mm = mapper.Map<DepartmentVm>(dept);
            return View(mm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentVm model)
        {
            var data = mapper.Map<Department>(model);
          await  department.Update(data);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {

            var data = await department.GetById(id);
           await department.Delete(data);

            return RedirectToAction("index");

        }

        #endregion

        //[HttpPost]

        //public IActionResult Delete(DepartmentVm     dep)
        //{

        //    try
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.x = ex;
        //        return View(dep);
        //    }




    }
}
