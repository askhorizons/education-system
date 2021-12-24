using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Persistence.Configurations
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("Option", "Lookup");

            builder.HasKey(p => p.OptionId)
                .HasName("PK_Option");

            builder.Property(p => p.OptionId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                    .HasColumnType("NVARCHAR(10)")
                    .IsRequired();
        }
    }
}
