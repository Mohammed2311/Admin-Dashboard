using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohammed.BL.Interface;
using Mohammed.BL.Models;
using Mohammed.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Mohammed.DAL.Entity;

namespace Mohammed.BL.Repository
{
   public class EmployeeRep : IEmployeeRep
    {

        private readonly MoContext mo ;
        public EmployeeRep(MoContext context)
        {
            mo = context;
        }

        public async Task Create(Employee employee)
        {
            
            await mo.Employees.AddAsync(employee);
            await mo.SaveChangesAsync();
        }
        public void Create1(Employee obj)
        {
            mo.Employees.Add(obj);
            mo.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var emp = await mo.Employees.FirstOrDefaultAsync(e => e.Id == id);
            emp.IsDleted = true;
            await mo.SaveChangesAsync();
        }

        public async Task Edit(Employee employee)
        {
            mo.Entry(employee).State = EntityState.Modified;
            await mo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var data = await mo.Employees.Include("Department").Where(e => e.IsDleted == false).ToListAsync();
            return data; 
        }
        


        public async Task<Employee> GetById(int id)
        {
            var emp = await mo.Employees.FirstOrDefaultAsync(e => e.Id == id && e.IsDleted ==false);
            return emp;
        }

        public async Task<IEnumerable<Employee>> Search(string search)
        {
            var data =await mo.Employees.Include("Department")
                .Where(e => e.Name.ToLower().Contains(search.ToLower())).ToListAsync();
            if (data == null)
            {
                return await GetAll();
            }
            return data;

        }
    }
}
