using BookEventApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUser(SignUpModel signUp);
        Task<SignInResult> LoginUser(LoginModel loginModel);

        Task SignOut();
        string GetEmail(string organiser);
    }
}
