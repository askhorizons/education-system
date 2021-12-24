using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Persistence.Configurations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Class", "Lookup");

            builder.HasKey(p => p.ClassId)
                .HasName("PK_Class");

            builder.Property(p => p.ClassId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                    .HasColumnType("NVARCHAR(10)")
                    .IsRequired();
        }
    }
}
