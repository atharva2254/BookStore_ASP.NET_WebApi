using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.Interfaces.Repository
{
    public interface ICartItemRepository
    {

        Task<List<CartItem>> GetAllAsync(string userId);
        Task ClearCartItems(string userId);
    }
}
