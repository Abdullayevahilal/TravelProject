using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Repository.Repositories.AuthRepositories;
using Travel.Models.Account;

namespace Travel.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;

        public AccountController(IMapper mapper,
                                 IAuthRepository authRepository)
        {
            _mapper = mapper;
            _authRepository = authRepository;
        }
        public IActionResult Register(RegisterViewModel model)
        {
            return View();
        }
        public IActionResult Login(LoginViewModel model)
        {
            return View();
        }
        public IActionResult UserDashboard()
        {
            return View();
        }
    }
}