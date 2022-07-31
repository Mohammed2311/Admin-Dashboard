using Mohammed.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mohammed.BL.Interface
{
  public  interface ICountryRep
    {
        Task<Country> GetById(int id);
        Task<IEnumerable<Country>> Get(Expression<Func<Country, bool>> filter = null);
    }
}
