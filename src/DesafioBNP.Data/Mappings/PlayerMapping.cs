using DesafioBNP.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBNP.Data.Mappings
{
    public class PlayerMapping : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Age)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.ShirtNumber)
                .IsRequired()
                .HasColumnType("int");

            builder.ToTable("Players");
        }
    }
}