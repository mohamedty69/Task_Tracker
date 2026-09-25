using Application.Features.Auth.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.IServices
{
    public interface IIdentityService
    {
        public Task<IdentityResult> RegisterUser(RegisterDto registerDto);
        public Task<ApplicationUser> Login(LoginDto loginDto); 
    }
}
