﻿using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasIndex(t => t.Name).IsUnique();

            builder.HasMany(t => t.HomeMatches)
                .WithOne(m => m.HomeTeam)
                .HasForeignKey(m => m.HomeTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.AwayMatches)
                .WithOne(m => m.AwayTeam)
                .HasForeignKey(m => m.AwayTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                     new Team
                     {
                         Id = 1,
                         Name = "Tivoli Gardens F.C.",
                         CreatedDate = new DateTime(2024, 8, 28),
                         LeagueId = 1,
                         CoachId = 1,

                     },
                     new Team
                     {
                         Id = 2,
                         Name = "Waterhouse F.C.",
                         CreatedDate = new DateTime(2024, 8, 28),
                         LeagueId = 1,
                         CoachId = 2,
                     },
                     new Team
                     {
                         Id = 3,
                         Name = "Humble Lions F.C.",
                         CreatedDate = new DateTime(2024, 8, 28),
                         LeagueId = 1,
                         CoachId = 3,
                     }

                 );
        }
    }
}
