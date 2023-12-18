using BookEventApp.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp.IRepository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUser(SignUp user);
        Task<SignInResult> LoginUser(Login user);
        Task SignOut();
        string GetEmail(string organiser);
    }
}
