using Microsoft.EntityFrameworkCore;
using PhonebookWebApi.Data.Entities;

namespace PhonebookWebApi.Data.Context
{
    public class PhoneBookWebApiDbContext : DbContext
    {
        public PhoneBookWebApiDbContext(DbContextOptions<PhoneBookWebApiDbContext> options) : base(options) { }
            public DbSet<Contact> Contacts { get; set; }
    }
}
