using IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Mapping;
using IsTakipProject.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Contexts
{
    public class IsTakipContext: IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=IsTakipDB;integrated security=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new GorevMap());
            modelBuilder.ApplyConfiguration(new AciliyetMap());
            modelBuilder.ApplyConfiguration(new RaporMap());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Gorev> Gorevler { get; set; }
        public DbSet<Aciliyet> Aciliyetler { get; set; }
        public DbSet<Rapor> Raporlar { get; set; }
        public DbSet<Bildirim> Bildirimler { get; set; }
    }
}
