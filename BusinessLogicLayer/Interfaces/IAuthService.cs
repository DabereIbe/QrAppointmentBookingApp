using System;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Interfaces;

public interface IAuthService
{
    Task<SignInResult> LoginAsync(string email, string password, bool rememberMe);
    Task<IdentityResult> RegisterAsync(User user, string password);
    Task LogoutAsync();
}
