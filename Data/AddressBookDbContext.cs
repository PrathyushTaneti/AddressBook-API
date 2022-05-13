using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AddressBookAPI.Models;

namespace AddressBookAPI.Data
{
    public class AddressBookDbContext : DbContext
    {
        public AddressBookDbContext (DbContextOptions<AddressBookDbContext> options) : base(options)
        { 
        }

        public DbSet<ContactDetail> ContactDetails { get; set; } 
    }
}
