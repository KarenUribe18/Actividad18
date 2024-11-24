﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Actividad18.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }
    }
}
