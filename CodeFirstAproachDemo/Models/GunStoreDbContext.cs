using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstAproachDemo.Models
{
    public class GunStoreDbContext : DbContext
    {
        public GunStoreDbContext() : base("GunStoreConnectionString")
        {
        }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<WeaponType> WeaponTypes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}