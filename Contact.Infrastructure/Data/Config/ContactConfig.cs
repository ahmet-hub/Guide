using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.Infrastructure.Data.Config
{
    public class ContactConfig : IEntityTypeConfiguration<Domain.Entities.Contact>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()").IsRequired().ValueGeneratedOnAdd();
        }
    }
}
