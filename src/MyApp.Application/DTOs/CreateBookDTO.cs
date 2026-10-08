using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.DTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
