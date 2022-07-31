using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohammed.BL.Models;
using Mohammed.DAL.Entity;

namespace Mohammed.BL.Interface
{
    public interface IEmployeeRep
    {
        
        Task<IEnumerable<Employee>> Search(string search);
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task Delete(int id);
        Task Create(Employee employee);
        Task Edit(Employee employee);
        public void Create1(Employee obj);
    }
}
