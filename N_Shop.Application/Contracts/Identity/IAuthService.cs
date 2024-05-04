using N_Shop.Application.Models.Identity;

namespace N_Shop.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponseModel> Login(AuthRequestModel authRequestModel);
        Task<RegistrationResponseModel> Register(RegistrationRequestModel registrationRequestModel);
    }
}
