namespace N_Shop.Application.Models.Identity
{
    public class AuthRequestModel : IIdentityModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
