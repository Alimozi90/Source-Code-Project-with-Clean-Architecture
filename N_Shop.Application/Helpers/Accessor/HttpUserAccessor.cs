using Microsoft.AspNetCore.Http;
using N_Shop.Application.Contracts.Accessor;

namespace N_Shop.Application.Helpers.Accessor
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _accessor;
        public UserAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public int UserId => int.Parse(_accessor.HttpContext.User.FindFirst("uid").Value);
    }
}
