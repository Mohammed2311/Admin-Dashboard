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
    public class DistricRep : IDistricRep
    {
        private readonly MoContext mo;

        public DistricRep(MoContext mo)
        {
            this.mo = mo;
        }
        public async Task<IEnumerable<Distric>> Get(Expression<Func<Distric, bool>> filter = null)
        {
            if (filter == null)
            {
                var data =await mo.Districs.ToListAsync();
                return data;
            }
            else
            {
                
                var data = await mo.Districs.Where(filter).ToListAsync();
                return data;
            }
           
        }

        public async Task<Distric> GetById(int id)
        {
            var data = await mo.Districs.Where(a => a.ID == id).FirstOrDefaultAsync();
            return data;
        }
    }
}
