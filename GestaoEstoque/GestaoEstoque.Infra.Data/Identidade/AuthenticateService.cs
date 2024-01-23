using GestaoEstoque.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace GestaoEstoque.Infra.Data.Identidade
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticateService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var resultado = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            return resultado.Succeeded;
        }
        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser { UserName = email, Email = email };

            var resultado = await _userManager.CreateAsync(applicationUser, password);

            if(resultado.Succeeded) { await _signInManager.SignInAsync(applicationUser, isPersistent: false); }

            return resultado.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
