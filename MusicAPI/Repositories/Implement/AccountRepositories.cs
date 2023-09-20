using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MusicAPI.Models;
using MusicAPI.Repositories.Interface;
using MusicAPI.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicAPI.Repositories.Implement
{
    public class AccountRepositories : IAccountRepository
    {
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepositories(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _usermanager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<string> SignInAsync(SignInModels model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                return string.Empty;
            }
            var arthClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(20),
                claims: arthClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModels model)
        {
            var user = new User { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, UserName = model.Email };
            return await _usermanager.CreateAsync(user, model.Password);
        }
    }
}
