using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAutomationProject.Identity
{
    public class SapIdentityDbContext : IdentityDbContext<SapIdentityUser, SapIdentityRole, string>
    {
        public SapIdentityDbContext(DbContextOptions<SapIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
