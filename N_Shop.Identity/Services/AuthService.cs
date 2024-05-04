using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using N_Shop.Application.Constants.Const;
using N_Shop.Application.Contracts.Identity;
using N_Shop.Application.Contracts.Persistence.Users;
using N_Shop.Application.Exceptions;
using N_Shop.Application.Models.Identity;
using N_Shop.Application.Models.Identity.Validators;
using N_Shop.Domain.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N_Shop.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;
        private readonly IMapper _mapper;
        public AuthService(IUserRepository userRepository,
            IOptions<JwtSettings> jwtSettings, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings.Value;
            _mapper = mapper;
        }


        #region Register
        public async Task<RegistrationResponseModel> Register(RegistrationRequestModel registrationRequestModel)
        {
            var validator = new RegistrationRequestModelValidator(_userRepository);

            var validatorRsult = await validator.ValidateAsync(registrationRequestModel);

            if (!validatorRsult.IsValid)
                throw new ValidationException(validatorRsult);

            var user = _mapper.Map<User>(registrationRequestModel);

            user.RoleId = 1;
            user.Status = 1;

            user = await _userRepository.Add(user);

            if (user != null)
            {
                return new RegistrationResponseModel() { Id = user.Id };
            }
            else
            {
                throw new Exception($"Failid Create User");
            }
        }
        #endregion

        #region Login
        public async Task<AuthResponseModel> Login(AuthRequestModel authRequestModel)
        {
            var validator = new AuthRequestModelValidator(_userRepository);

            var validatorRsult = await validator.ValidateAsync(authRequestModel);

            if (!validatorRsult.IsValid)
                throw new ValidationException(validatorRsult);


            var user = await _userRepository.GetUserByUserNamePassword(authRequestModel.UserName, authRequestModel.Password);

            if (user == null)
                throw new Exception($"credentials for {authRequestModel.UserName} arent valid.");

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthResponseModel response = new AuthResponseModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };

            return response;
        }
        #endregion

        #region GenerateToken
        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            //var userClaims = await _userManager.GetClaimsAsync(user);

            //var roles = await _userManager.GetRolesAsync(user);

            //var role = user.RoleId;


            //for (int i = 0; i < roles.Count; i++)
            //{
            //    roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            //}

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(CustomCliamTypes.Uroleid,user.RoleId.ToString()),
                new Claim(CustomCliamTypes.Urolename,user.Role.Name),
                new Claim(CustomCliamTypes.Uid,user.Id.ToString()),
            };
            //.Union(userClaims)
            //.Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        #endregion

    }

}
