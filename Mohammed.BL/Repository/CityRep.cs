using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohammed.BL.Interface;
using Mohammed.BL.Models;
using Mohammed.DAL.DataBase;
using Mohammed.DAL.Entity;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace WebApplication2.BL.Repository
{
   public class CityRep : ICityRep
    {

        private readonly MoContext mo ;
        public CityRep(MoContext mo)
        {
            this.mo = mo;
        }

        public  async Task<IEnumerable<City>> Get(Expression<Func<City, bool>> filter = null)
        {
            if (filter == null)
            {
                var data = await mo.Cities.ToListAsync();
                return data;
            }
            else
            {
                var data = await mo.Cities.Where(filter).ToListAsync();
                return data;
            }
        }

        public async Task<City> GetById(int id)
        {
            var data = await mo.Cities.Where(c => c.ID == id).FirstOrDefaultAsync();
            return data;
        }
    }
}
