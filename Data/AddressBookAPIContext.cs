using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AddressBookAPI.Models;

namespace AddressBookAPI.Data
{
    public class AddressBookAPIContext : DbContext
    {
        public AddressBookAPIContext (DbContextOptions<AddressBookAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AddressBookAPI.Models.ContactDetail>? ContactDetails { get; set; } //empty list
    }
}
