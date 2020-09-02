using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Repository.Models;
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
        public IActionResult Register(RegisterViewModel register)
        {
            bool checkUser = _authRepository.CheckEmail(register.Email);

            if (checkUser)
            {
                ModelState.AddModelError("Email", "This email is already registered");
            }
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<RegisterViewModel, User>(register);
                user.Token = Guid.NewGuid().ToString();
                user.Status = true;
                _authRepository.Register(user);

                return RedirectToAction("index", "home");
            }
            return View("~/Views/Account/Register.cshtml",new AccountViewModel{

                Register = register
            });
        }
        public IActionResult Login(LoginViewModel login)
        {
            return Ok(login);
        }
        public IActionResult UserDashboard()
        {
            return View();
        }
    }
}