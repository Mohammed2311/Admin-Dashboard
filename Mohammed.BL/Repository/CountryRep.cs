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
using Mohammed.BL.Interface;
using Mohammed.DAL.Entity;
using System.Linq.Expressions;

namespace WebApplication2.BL.Repository
{
   public class CountryRep : ICountryRep
    {

        private readonly MoContext mo ;

        public CountryRep(MoContext mo )
        {
            this.mo = mo;
        }
        public async Task<IEnumerable<Country>> Get(Expression<Func<Country, bool>> filter = null)
        {
            if (filter==null)
            {
                var data =await mo.Countries.ToListAsync();
                return data;
            }
            else
            {
                var data = await mo.Countries.Where(filter).ToListAsync();
                return data;
            }
        }

        public async Task<Country> GetById(int id)
        {
            var data = await mo.Countries.Where(c => c.ID == id).FirstOrDefaultAsync();
            return data;
        }
    }
}
