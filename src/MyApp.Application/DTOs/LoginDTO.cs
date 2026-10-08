using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
