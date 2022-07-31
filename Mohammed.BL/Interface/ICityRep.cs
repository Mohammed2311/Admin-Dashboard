using Mohammed.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mohammed.BL.Interface
{
    public interface ICityRep
    {
        Task<City> GetById(int id);
        Task<IEnumerable<City>> Get(Expression<Func<City, bool>> filter = null);
    }
}
