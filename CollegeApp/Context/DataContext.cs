using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyApp.Entities;
using CompanyApp.Models;

namespace CompanyApp.Context
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CompanyApp.Entities.College> College { get; set; }

        public DbSet<CompanyApp.Entities.Department> Department { get; set; }

        public DbSet<CompanyApp.Entities.User> User { get; set; }

        public DbSet<CompanyApp.Models.UserModel> UserModel { get; set; }
             
    }
}
