using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpeechTherapist.Web.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeechTherapist.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Exercise> Exercise { get; set; }

    }
}
