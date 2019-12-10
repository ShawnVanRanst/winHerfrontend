using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnBoardFlight.Model;
using OnBoardFlight_Backend.Model;
using OnBoardFlight_Backend.Model.MediaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        #region DbSets

        public DbSet<Flight> Flights { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Media> Mediafiles { get; internal set; }
        #endregion


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Music>();
            builder.Entity<Movie>();
            builder.Entity<Serie>();
            builder.Entity<SerieEpisode>();

            base.OnModelCreating(builder);
        }

        
    }
}
