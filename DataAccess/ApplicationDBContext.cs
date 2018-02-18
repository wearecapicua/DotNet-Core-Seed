using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace DataAccess
{
    //Database context of our application that inherits from net core Identity database context
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public ApplicationDbContext()
           : base()
        {
        }

       
        //Tables that match our context with our app tables in the database.
        public DbSet<Customer> Customers { get; set; }
    }
}
