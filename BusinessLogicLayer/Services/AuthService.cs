using System;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services;

public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
    private readonly AppDbContext _context;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        _context = context;
    }

        public async Task<SignInResult> LoginAsync(string matricNumber, string password, bool rememberMe)
        {
            // var users = await _context.Users.ToListAsync();
            // if (users == null)
            // {
            //     await _userManager.CreateAsync(new User{
            //         FirstName = "Daberechukwu",
            //         LastName = "Ibeakanma",
            //         MatricNumber = "20191153822"
            //     }, "Test@123");
            // }
            var user = await _userManager.FindByNameAsync(matricNumber);
            return await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);
        }

        public async Task<IdentityResult> RegisterAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
