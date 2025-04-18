﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Domain.Enums;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using RashaPrimeWeb.Domain.Enums;
using LoginViewModel = OurResumeIR.Application.ViewModels.Account.LoginViewModel;
using RegisterViewModel = OurResumeIR.Application.ViewModels.Account.RegisterViewModel;

namespace OurResumeIR.Application.Services.Implementation
{
    public class UserService : IUserService
    {

        private  UserManager<User> _userManager;
        private  SignInManager<User> _signInManager;
        //private readonly RoleManager<ApplicationRole> _roleManager;
        public UserService(IUserRepository userRepository,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<RegisterResult> RegisterUser(RegisterViewModel viewModel)
        {
            if (await _userRepository.EmailIsExist(viewModel.Email))
            {
                return RegisterResult.DupplicateEmail;
            }

            if (viewModel.Password != viewModel.RePassword)
            {
                return RegisterResult.UnequalPassAndRePass;
            }


            var user = new User
            {
                Email = viewModel.Email,
                UserName = viewModel.Email,

            };

            var status = await _userManager.CreateAsync(user, viewModel.Password);
            if (status.Succeeded)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Email),
                         new Claim("CodeMeli", "3"),

                    };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await _signInManager.SignInAsync(user, properties);

            }
      
            return RegisterResult.Success;
        }


        public async Task<LoginResult> LoginUser(LoginViewModel viewModel)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);

            if (user == null)
                return LoginResult.UserNotFound;

            var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);

            if (result.Succeeded)
            {
                return LoginResult.Success;
            }

            return LoginResult.InvalidPassword;
        }


    }
}
