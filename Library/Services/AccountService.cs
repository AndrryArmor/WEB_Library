using AutoMapper;
using Library.Entities;
using Library.Models;
using Library.Objects;
using Library.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public SignInResult Login(UserLoginModel userLoginModel)
        {
            return _unitOfWork.SignInManager
                .PasswordSignInAsync(userLoginModel.Email, userLoginModel.Password, userLoginModel.RememberMe, false)
                .Result;
        }

        public IdentityResult Register(UserRegisterModel userRegisterModel)
        {
            var user = _mapper.Map<User>(userRegisterModel);
            return _unitOfWork.UserManager.CreateAsync(user, userRegisterModel.Password).Result;
        }

        public void SignOut()
        {
            _unitOfWork.SignInManager.SignOutAsync().RunSynchronously();
        }
    }
}
