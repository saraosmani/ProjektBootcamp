﻿using Microsoft.EntityFrameworkCore;
using RestaurantApp.API.Data.Models;
using System.Collections.Generic;

namespace RestaurantApp.API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}
