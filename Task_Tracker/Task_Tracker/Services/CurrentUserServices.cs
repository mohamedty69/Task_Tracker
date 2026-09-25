using Application.Interfaces.IServices;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Task_Tracker.Controllers;

namespace Task_Tracker.Services
{
    public class CurrentUserServices : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId { get => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)?? throw new NullReferenceException("User need to login first"); }  
        
    }
}
