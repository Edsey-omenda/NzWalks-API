using Microsoft.EntityFrameworkCore;
using NzWalks.Models.Domain;
using System.Xml.Linq;

namespace NzWalks.Data
{
    public class NzWalksDbContext: DbContext
    {
        public NzWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for Difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("c900add3-213f-4615-bcd7-788c75805d91"),
                    Name = "Easy"
                },
                new Difficulty()
                 {
                    Id = Guid.Parse("b984ecd3-e578-43c5-8565-6ec56cac3216"),
                    Name = "Medium"
                 },
                new Difficulty()
                  {
                    Id = Guid.Parse("b75d59ff-04e4-44ff-8bb1-d5f68ee8fec8"),
                    Name = "Hard"
                }
            };

            //Seed difficulties to Database.
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("1270242a-44a1-42d6-9d0d-c1372c852e1a"),
                    Name = "Globalization Partners",
                    Code = "GP",
                    RegionImageUrl = "gp.jpeg"
                },
                 new Region()
                {
                    Id = Guid.Parse("0d32f077-5f74-40ba-bd0f-3fa2b6e7757c"),
                    Name = "Stem Center",
                    Code = "SC",
                    RegionImageUrl = "stem.jpeg"
                },
                  new Region()
                {
                    Id = Guid.Parse("76cdfc42-5e6b-4696-ac77-ea8759ce71d0"),
                    Name = "Kenya",
                    Code = "KE",
                    RegionImageUrl = "kenya.jpeg"
                },
                   new Region()
                {
                    Id = Guid.Parse("f807fc4d-69d7-4da7-9e2b-b0d63f75d9c6"),
                    Name = "America",
                    Code = "USA",
                    RegionImageUrl = "states.jpeg"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
