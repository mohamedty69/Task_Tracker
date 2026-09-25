using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Auth.Dto
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
