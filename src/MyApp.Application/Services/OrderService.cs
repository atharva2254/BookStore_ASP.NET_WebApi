using MyApp.Application.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.Services
{
    internal class OrderService
    {
        public void CreateOrder(OrderDTO order)
        {
            var newOrder = new Order
            {
                UserId = order.UserId,
                TotalAmount = order.TotalAmount,
            };

        }
        
    }
}
