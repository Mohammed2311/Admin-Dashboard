using Mohammed.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mohammed.BL.Interface
{
   public interface IDistricRep
    {
        Task<Distric> GetById(int id);
        Task<IEnumerable<Distric>> Get(Expression<Func<Distric, bool>> filter = null);
    }
}
