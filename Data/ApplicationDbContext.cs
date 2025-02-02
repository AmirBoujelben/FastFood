﻿using FastFood.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FastFood.ViewModels;

namespace FastFood.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<FastFood.ViewModels.OrderDetailsViewModel> OrderDetailsViewModel { get; set; } = default!;
    }
}
