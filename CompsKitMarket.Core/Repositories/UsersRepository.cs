using CompsKitMarket.Core.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsKitMarket.Core.Repositories
{
    public class UsersRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly MarketContext _marketContext;


        public UsersRepository(UserManager<User> userManager, RoleManager<Role> roleManager,
            SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor, MarketContext marketContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _marketContext = marketContext;
        }

        public async Task<string> GetUserFio()
        {
            var username = _httpContextAccessor.HttpContext?.User.Identity?.Name;
            var usver = await _marketContext.Users
                .FirstAsync(x => x.UserName == username);

            return usver.Surname
                + (!string.IsNullOrEmpty(usver.Name) ? $" {usver.Name[0]}." : "")
                + (!string.IsNullOrEmpty(usver.SecondName) ? $" {usver.SecondName[0]}." : "");
        }
    }
}
