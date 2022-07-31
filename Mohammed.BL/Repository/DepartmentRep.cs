using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using Mohammed.DAL.DataBase;
using Mohammed.DAL.Entity;
using Mohammed.BL.Interface;

namespace Mohammed.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {

        private readonly MoContext mo;
        public DepartmentRep(MoContext context)
        {
            mo = context;
        }
        public async Task  Create(Department d)
        {
            Department department1 = new Department();
            department1.ID = d.ID;
            department1.Name = d.Name;
            department1.Code = d.Code;
            await mo.Departments.AddAsync(department1);
             await mo.SaveChangesAsync();
        }
        public IEnumerable<Department> Get()
        {
            var data = mo.Departments.Where(e => e.IsDeleted == false).Select(a=>a);
            return data;
        }
        public async Task Delete(Department department)
        {
            var data = mo.Departments.Find(department.ID);
            data.IsDeleted = true;
          await  mo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
           return await mo.Departments.Where(a=> a.IsDeleted == false).Select(a=>a).ToListAsync();

        }

        public async Task<Department> GetById(int id)
        {
            var data =await mo.Departments.Where(a => a.ID == id && a.IsDeleted == false).FirstOrDefaultAsync();
            return data; 
        }

       
        public async Task Update(Department department)
        {
            mo.Entry(department).State = EntityState.Modified;
            await mo.SaveChangesAsync();

        }

        public async Task<IEnumerable<Department>> Search( string name)
        {

            var data = await mo.Departments.Where(a=>a.Name.Contains(name)).ToListAsync();
            return data;

        }


    }
}
