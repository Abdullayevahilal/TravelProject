using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.ShoppingRepositories
{
   
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TravelDbContext _context;
        public CategoryRepository(TravelDbContext context)
        {

            _context = context;
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Include("Department").FirstOrDefault(c => c.Id == id);
        }

        public object GetCategoryById()
        {
            throw new NotImplementedException();
        }
    }
}
