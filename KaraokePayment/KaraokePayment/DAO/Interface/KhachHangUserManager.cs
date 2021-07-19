using KaraokePayment.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KaraokePayment.DAO.Interface
{
    public class KhachHangUserManager : UserManager<KhachHang>
    {
        public KhachHangUserManager(IUserStore<KhachHang> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<KhachHang> passwordHasher, IEnumerable<IUserValidator<KhachHang>> userValidators, IEnumerable<IPasswordValidator<KhachHang>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<KhachHang>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
        public async Task<KhachHang> GetKhachHang(ClaimsPrincipal principal)
        {
            var kh = await GetUserAsync(principal);
            return kh;
        }
    }
}
