using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class SehirConfig : IEntityTypeConfiguration<Sehir>
    {
        public void Configure(EntityTypeBuilder<Sehir> builder)
        {
            builder.HasData(
                new Sehir { Id = 1, SehirAdi = "İstanbul", UlkeAdi = "Türkiye" },
                new Sehir { Id = 2, SehirAdi = "Ankara", UlkeAdi = "Türkiye" },
                new Sehir { Id = 3, SehirAdi = "İzmir", UlkeAdi = "Türkiye" }
                );
        }
    }
}
