using MyApp.Application.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByEmailAsync(string Email);
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task DeleteAsync(User user);
    }
}
