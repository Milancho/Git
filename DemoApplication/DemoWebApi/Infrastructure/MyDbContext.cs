using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using DemoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApi.Infrastructure
{
    public class MyDbContext : DemoContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Demo"].ConnectionString);
        }
    }
}