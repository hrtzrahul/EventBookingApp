﻿using AutoMapper;
using BookEventApp.Entities;
using BookEventApp.Interfaces;
using BookEventApp.IRepository;
using BookEventApp.Mapper;
using BookEventApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        public async Task<IdentityResult> CreateUser(SignUpModel signUpModel)
        {
            //mapping from application model to entity
            var mapped = ObjectMapper.Mapper.Map<SignUp>(signUpModel);
            if (mapped == null)
                throw new ApplicationException($"Entity could not be mapped.");

            //calling data layer using mapped
            //outputting result in the same return type
            var entityDto = await _accountRepository.CreateUser(mapped);
            return entityDto;


        }


        public async Task<SignInResult> LoginUser(LoginModel loginModel)
        {
            var mapped = ObjectMapper.Mapper.Map<Login>(loginModel);
            if (mapped == null)
                throw new ApplicationException($"Entity could not be mapped.");

            //calling data layer using mapped
            //outputting result in the same return type
            var entityDto = await _accountRepository.LoginUser(mapped);
            return entityDto;
        }

        public async Task SignOut()
        {
            await _accountRepository.SignOut();
        }

        public string GetEmail(string organiser)
        {
            return _accountRepository.GetEmail(organiser);
        }
    }
}
