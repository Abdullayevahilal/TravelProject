using Microsoft.AspNetCore.Mvc;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.ViewComponents
{
    public class MenuViewComponent :ViewComponent

    {
        private readonly IDepartmentRepository _departmentRepository;
        public MenuViewComponent(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
       
    }
}
