using System;
using System.Collections.Generic;
using System.Text;
using AdminLTE.MVC.Models;
using AdminLTE.MVC.Models.School;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminLTE.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
    }
}
