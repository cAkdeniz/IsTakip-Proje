using IsTakipProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Mapping
{
    public class AciliyetMap : IEntityTypeConfiguration<Aciliyet>
    {
        public void Configure(EntityTypeBuilder<Aciliyet> builder)
        {
            builder.Property(x => x.Tanim).HasMaxLength(30);
        }
    }
}
