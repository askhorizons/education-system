using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Persistence.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("Application", "Admission");

            builder.HasKey(p => p.ApplicationId)
                .HasName("PK_Application");

            builder.Property(p => p.ApplicationId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CandidateId)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(p => p.ClassId)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(p => p.SessionId)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(p => p.FeePayerId)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(p => p.ParentId)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(p => p.OptionOneId)
                .HasColumnType("INT")
                .IsRequired(false);

            builder.Property(p => p.OptionTwoId)
                .HasColumnType("INT")
                .IsRequired(false);

            builder.HasOne(p => p.Candidate)
                .WithMany(p => p.Applications)
                .HasForeignKey(p => p.CandidateId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Application_Candidate");

            builder.HasOne(p => p.Class)
                .WithMany(p => p.Applications)
                .HasForeignKey(p => p.ClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Application_Class");

            builder.HasOne(p => p.Session)
                .WithMany(p => p.Applications)
                .HasForeignKey(p => p.SessionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Application_Session");

            builder.HasOne(p => p.FeePayer)
                .WithMany(p => p.ApplicationFeePayers)
                .HasForeignKey(p => p.FeePayerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Application_FeePayer");

            builder.HasOne(p => p.Parent)
                .WithMany(p => p.ApplicationParents)
                .HasForeignKey(p => p.ParentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Application_Parent");

            builder.HasOne(p => p.OptionOne)
                .WithMany(p => p.ApplicationsOptionOne)
                .HasForeignKey(p => p.OptionOneId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Application_OptionOne");

            builder.HasOne(p => p.OptionTwo)
                .WithMany(p => p.ApplicationsOptionTwo)
                .HasForeignKey(p => p.OptionTwoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Application_OptionTwo");
        }
    }
}
