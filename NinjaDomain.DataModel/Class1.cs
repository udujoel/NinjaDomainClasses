﻿using System.Data.Entity;

using NinjaDomainClasses;

namespace NinjaDomain.DataModel
{
    public class NinjaContext : DbContext
    {
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<NinjaEquiptment> Equiptments { get; set; }


    }
}
