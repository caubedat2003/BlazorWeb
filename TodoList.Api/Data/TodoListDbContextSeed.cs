﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TodoList.Api.Entities;
using TodoList.Models.Enums;
using Task = System.Threading.Tasks.Task;

namespace TodoList.Api.Data
// Khi khoi dong tu dong bom du lieu mau vao DB
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async Task SeedAsync(TodoListDbContext context, ILogger<TodoListDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "admin1@gmail.com",
                    NormalizedEmail = "ADMIN1@GMAIL.COM",
                    PhoneNumber = "0123456789",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserRole = UserRole.Receptionist
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123#");
                context.Users.Add(user);
            }
            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Entities.Task(){
                    Id = Guid.NewGuid(),
                    Name = "Same tasks 1",
                    CreatedDate = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.Open,
                });
            }
            if(!context.Patients.Any())
            {
                context.Patients.Add(new Patient()
                {
                    PatientId = Guid.NewGuid(),
                    Name = "Benh nhan A",
                    Gender = Gender.Nam,
                    DateOfBirth = DateTime.Now,
                    Job = "Doanh nhan",
                    PhoneNumber = "0000000000",
                    Address = "Cau Giay, Ha Noi",
                    CreatedDate = DateTime.Now
                });
            }
            if (!context.PageRoleAssignments.Any())
            {
                context.PageRoleAssignments.Add(new Models.PageRoleAssignment()
                {
                    Id = 1,
                    PageName = "ManageUserRole",
                    IsAdmin = true,
                    IsReceptionist = false,
                    IsDoctor = false,
                    IsCashier = false,
                    IsPharmacist = false,
                });
            }
            await context.SaveChangesAsync();
        }
    }
}
