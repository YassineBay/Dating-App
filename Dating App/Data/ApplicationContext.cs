using Dating_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_App.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Value> Values { get; set; }
    }
}
