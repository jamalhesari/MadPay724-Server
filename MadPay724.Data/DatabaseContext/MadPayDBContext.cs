﻿using MadPay724.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.DatabaseContext
{
    public class MadPayDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=(local);Initial Catalog= MadPay724DB; Integrated Security = True; MultipleActiveResultSets=True;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
    }
}
