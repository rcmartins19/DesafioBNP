using DesafioBNP.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBNP.Data.Mappings
{
    public class FootballTeamMapping : IEntityTypeConfiguration<FootballTeam>
    {
        public void Configure(EntityTypeBuilder<FootballTeam> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.TeamName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.City)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.FoundationYear)
                .IsRequired()
                .HasColumnType("int");


            // 1 : N => FootballTeam : Players
            builder.HasMany(f => f.Players)
                .WithOne(p => p.FootballTeam)
                .HasForeignKey(p => p.TeamId);

            builder.ToTable("FootballTeams");
        }
    }
}