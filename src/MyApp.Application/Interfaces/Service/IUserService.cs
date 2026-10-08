using MyApp.Application.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.Interfaces.Service
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        //Task<User> GetUserById(int id);
        Task<User?> RegisterAsync(RegisterDTO request);
        Task<string?> LoginAsync(LoginDTO request);
    }
}
