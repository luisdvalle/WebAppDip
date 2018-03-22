using Microsoft.EntityFrameworkCore;
using PracticeTestTafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeTestTafe.Services
{
    public class MyDbContext : DbContext
    {
        public DbSet<Category> CategoryTbl { get; set; }
        public DbSet<Product> ProductTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=PracticeTestDB; Trusted_Connection=True");
        }
    }
}
