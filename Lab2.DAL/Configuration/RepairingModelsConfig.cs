using Lab2.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab2.DAL.Configuration
{
    public class RepairingModelsConfig : IEntityTypeConfiguration<RepairingModel>
    {
        public void Configure(EntityTypeBuilder<RepairingModel> builder)
        {
            builder.HasData(DbInitializer.RepairingModels);
        }
    }
}
