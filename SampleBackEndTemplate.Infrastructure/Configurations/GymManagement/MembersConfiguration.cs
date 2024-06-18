using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleBackEndTemplate.Domain.Entities.GymManagement;
using SampleBackEndTemplate.Infrastructure.Configurations;
using System;

namespace SIDCMMS.Infrastructure.Configurations.GymManagement
{
    public class MembersConfiguration : BaseModelConfig, IEntityTypeConfiguration<Members>
    {
        public void Configure(EntityTypeBuilder<Members> builder)
        {
            TableName = "gym_members";
            builder.ToTable(TableName);

            builder.HasIndex(p => p.EmailAddress)
              .IsUnique().HasDatabaseName(UniquePrefix + "_" + "EmailAddress");

            builder.HasIndex(p => p.PhoneNumber)
              .IsUnique().HasDatabaseName(UniquePrefix + "_" + "PhoneNumber");

            builder.Property(t => t.EmailAddress)
               .HasMaxLength(150)
               .IsRequired(false);

            builder.Property(t => t.PhoneNumber)
                .HasMaxLength((Int32)EnumColumnLength.VARCHARDEFAULT)
                .IsRequired(false);

            builder.Property(t => t.FirstName)
                .HasMaxLength((Int32)EnumColumnLength.VARCHAR_FOR_150)
                .IsRequired(true);

            builder.Property(t => t.MiddleName)
                .HasMaxLength((Int32)EnumColumnLength.VARCHAR_FOR_150)
                .IsRequired(false);

            builder.Property(t => t.LastName)
                .HasMaxLength((Int32)EnumColumnLength.VARCHAR_FOR_150)
                .IsRequired(true);

            builder.Property(t => t.SuffixName)
                .HasMaxLength(10)
                .IsRequired(false);

            builder.Property(t => t.DateStartedAsAMember)
                .IsRequired(true);

            builder.Property(t => t.ValidityDateOfMembership)
                .IsRequired(true);

        }
    }
}