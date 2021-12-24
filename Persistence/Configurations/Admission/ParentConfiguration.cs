using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Persistence.Configurations
{
    public class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.ToTable("Parent", "Admission");

            builder.HasKey(p => p.ParentId)
                .HasName("PK_Parent");

            builder.Property(p => p.ParentId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();

            builder.Property(p => p.Cnic)
                .HasColumnType("NVARCHAR(13)")
                .IsRequired();

        }
    }
}
