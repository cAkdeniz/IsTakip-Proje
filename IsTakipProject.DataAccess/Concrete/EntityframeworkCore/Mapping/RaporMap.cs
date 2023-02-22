using IsTakipProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Mapping
{
    public class RaporMap : IEntityTypeConfiguration<Rapor>
    {
        public void Configure(EntityTypeBuilder<Rapor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Tanim).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Detay).HasColumnType("ntext");
        }
    }
}
