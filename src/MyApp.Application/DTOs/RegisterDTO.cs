using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.DTOs
{
    public class RegisterDTO
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
