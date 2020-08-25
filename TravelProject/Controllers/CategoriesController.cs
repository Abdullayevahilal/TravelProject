using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.ShoppingRepositories;
using Travel.Models;

namespace Travel.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CategoriesController(IMapper mapper,
                                    ICategoryRepository categoryRepository,
                                    IProductRepository productRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index(int id /*/*CategorySearchViewModel categorySearch*/)
        {
            var category = _categoryRepository.GetCategoryById(/*categorySearch.*/id);

            if (category == null) return NotFound();

            var products = _productRepository.GetProductsByCategoryId(category.Id);
                                                                      //categorySearch.Limit,
                                                                      //(categorySearch.Page - 1) * categorySearch.Limit,
                                                                      //Repository.Enums.ProdcutListing.Newness);
            //var productCount = _productRepository.GetProductCountByCategoryId(category.Id);

            var model = new CategoryListViewModel
            {
                Category = _mapper.Map<Category, CategoryViewModel>(category),
                Products = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products)
                //Count = productCount,
                //Page = categorySearch.Page,
                //Limit = categorySearch.Limit
            };

            return View(model);
        }
    }
    //public IActionResult Index()
    //    {
    //        return View();
    //    }
    }
