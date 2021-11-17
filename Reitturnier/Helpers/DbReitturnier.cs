using Microsoft.EntityFrameworkCore;
using Reitturnier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reitturnier.Helpers
{
    public class DbReitturnier : DbContext
    {
        public DbReitturnier(DbContextOptions<DbReitturnier> options) : base(options)
        {

        }

        public DbSet<Besitzer> Besitzer { get; set; }
    }
}
