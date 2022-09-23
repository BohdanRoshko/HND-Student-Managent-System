﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsWithRouting.Models;

namespace ProductsWithRouting.Services
{
    public class Data
    {
        public List<Product> Products = new List<Product>
        {
            new Product() {Id = 1, Name = "Student2", Fee = "8000"},
            new Product() {Id = 2, Name = "Student3", Fee = "2000"},
            new Product() {Id = 3, Name = "Student4", Fee = "3000"},
            new Product() {Id = 4, Name = "Student5", Fee = "1500"},
            new Product() {Id = 5, Name = "Student6", Fee = "1700"},
            new Product() {Id = 6, Name = "Student1", Fee = "900"},
        };

        public List<User> Users = new List<User>
        {
            new User() {Id = 0, Name = "UserAdmin", Email = "admin@gmail.com", Role = "admin"},
            new User() {Id = 0, Name = "Guest", Email = "guest@gmail.com", Role = "guest"},
            new User() {Id = 0, Name = "User", Email = "user1@gmail.com", Role = "user"},
            new User() {Id = 0, Name = "User2", Email = "user2@gmail.com", Role = "user"},

        };
    }
}
