using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Persistence.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidate", "Admission");

            builder.Property(p => p.CandidateId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("NVARCHAR(250)")
                .IsRequired();

            builder.Property(p => p.Cnic)
                .HasColumnType("NVARCHAR(13)")
                .IsRequired(false);

            builder.Property(p => p.DateOfBirth)
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(p => p.GenderId)
                .HasColumnType("INT")
                .IsRequired();

        }
    }
}
