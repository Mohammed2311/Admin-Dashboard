using AutoMapper;
using Mohammed.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohammed.BL.Models;

namespace Mohammed.BL.Mapper
{
   public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVm>();
            CreateMap<DepartmentVm, Department>();
            
            CreateMap<Employee, EmployeeVm>();
            CreateMap<EmployeeVm, Employee>();

            CreateMap<CityVm, City>();
            CreateMap<City, CityVm>();

            CreateMap<CountryVm, Country>();
            CreateMap<Country, CountryVm>();

            CreateMap<DistricVm, Distric>();
            CreateMap<Distric, DistricVm>();


        }
    }
}
