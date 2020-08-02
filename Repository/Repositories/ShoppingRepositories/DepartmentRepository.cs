 using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.ShoppingRepositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly TravelDbContext _context;
        public  DepartmentRepository (TravelDbContext context) {
            
            _context = context;
}
  
       public IEnumerable<Department> GetDepartmentsWithCategory()
        {
            return _context.Departments.Include("Categories")
                                       .Where(d => d.Status)
                                       .ToList();
        }
    } 


       
    }

