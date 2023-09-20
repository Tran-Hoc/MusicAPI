using Microsoft.AspNetCore.Identity;
using MusicAPI.ViewModel;

namespace MusicAPI.Repositories.Interface
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModels model);
        public Task<string> SignInAsync(SignInModels model);
    }
}
