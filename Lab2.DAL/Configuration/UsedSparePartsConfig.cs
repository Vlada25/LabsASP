using Lab2.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab2.DAL.Configuration
{
    public class UsedSparePartsConfig : IEntityTypeConfiguration<UsedSparePart>
    {
        public void Configure(EntityTypeBuilder<UsedSparePart> builder)
        {
            builder.HasData(DbInitializer.UsedSpareParts);
        }
    }
}
