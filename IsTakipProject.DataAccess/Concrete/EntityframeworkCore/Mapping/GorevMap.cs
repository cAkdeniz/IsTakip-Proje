using IsTakipProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Mapping
{
    public class GorevMap : IEntityTypeConfiguration<Gorev>
    {
        public void Configure(EntityTypeBuilder<Gorev> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Ad).HasMaxLength(200);
            builder.Property(x => x.Aciklama).HasColumnType("ntext");

            builder.HasOne(x => x.Aciliyet).WithMany(x => x.Gorevler).HasForeignKey(x => x.AciliyetId);
            builder.HasMany(x => x.Raporlar).WithOne(x => x.Gorev).HasForeignKey(x => x.GorevId);
        }
    }
}
