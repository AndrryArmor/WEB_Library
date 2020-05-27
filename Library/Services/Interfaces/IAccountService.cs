using Library.Models;
using Library.Objects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Library.Services
{
    public interface IAccountService
    {
        IdentityResult Register(UserRegisterModel userRegisterModel);
        SignInResult Login(UserLoginModel userLoginModel);
        void SignOut();
    }
}