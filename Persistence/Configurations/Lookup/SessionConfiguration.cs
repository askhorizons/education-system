using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Persistence.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Session", "Lookup");

            builder.HasKey(p => p.SessionId)
                .HasName("PK_Session");

            builder.Property(p => p.SessionId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                    .HasColumnType("NVARCHAR(10)")
                    .IsRequired();
        }
    }
}
