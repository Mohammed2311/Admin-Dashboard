using Mohammed.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohammed.BL.Interface
{
    public interface IDepartmentRep
    {
        IEnumerable<Department> Get();
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
        Task Create(Department department);
        Task Update(Department department);
        Task Delete(Department obj);
       Task<IEnumerable<Department>> Search(string name);

    }
}
