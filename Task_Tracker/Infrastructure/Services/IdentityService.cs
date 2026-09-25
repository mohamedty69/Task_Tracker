using Application.Features.Auth.Dto;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        private readonly IMapper _mapper;
        public IdentityService( UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ApplicationUser> Login(LoginDto loginDto)
        {
            var user =await _userManager.FindByEmailAsync(loginDto.Email);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (result)
                    return user;
            }
            return null;
        }
        public async Task<IdentityResult> RegisterUser(RegisterDto registerDto)
        {
            var user =await _userManager.FindByEmailAsync(registerDto.Email);
            if (user == null) {
                var mappedUser = _mapper.Map<ApplicationUser>(registerDto);
                var result = await _userManager.CreateAsync(mappedUser,registerDto.Password);
                if (result.Succeeded)
                    await _userManager.AddToRoleAsync(mappedUser, "User");
                return result;
            }
            return IdentityResult.Failed(new IdentityError { Code = "Invalid Register",Description = "This user was registered before" });
        }
    }
}
