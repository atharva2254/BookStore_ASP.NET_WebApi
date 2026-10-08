using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.DTOs
{
    public class OrderDTO
    {
        public Guid UserId { get; set; }
        public int TotalAmount { get; set; }
        public OrderItem OrderItems = null!;
        
    }
}
