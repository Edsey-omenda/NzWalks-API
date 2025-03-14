using Microsoft.AspNetCore.Identity;

namespace NzWalks.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
