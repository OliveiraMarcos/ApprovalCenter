using ApprovalCenter.Domain.Approval.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApprovalCenter.Infra.Data.ContextConfiguration
{
    class ApprovalContextConfiguration : IEntityTypeConfiguration<ApprovalEntity>
    {
        public void Configure(EntityTypeBuilder<ApprovalEntity> builder)
        {
            builder.ToTable("Approval");
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Subject)
                .HasColumnType("varchar(300)")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Justification)
                .HasColumnType("varchar(350)")
                .HasMaxLength(350);

            builder.Property(c => c.EmailApproval)
                .HasColumnType("varchar(250)")
                .HasMaxLength(250)
                .IsRequired();

            builder
                .HasOne(c => c.Category)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}
