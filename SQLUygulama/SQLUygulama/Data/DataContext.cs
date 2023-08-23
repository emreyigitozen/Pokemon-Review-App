using Microsoft.EntityFrameworkCore;
using SQLUygulama.Models;

namespace SQLUygulama.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)

        {

        }
        /* Bütün modellerimizi yerleştiriyoruz.*/
        public DbSet<Category> Categories { get; set; } /*İsimler çoğul olmalı */
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        /* Many to many  join table'lar için bunu kullanıyoruz. */
        {
            modelBuilder.Entity<PokemonCategory>()
                 .HasKey(pc => new { pc.PokemonId, pc.CategoryId });  /* Bu iki ıd'yi birbirine bağladık. */


            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.PokemonId);

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.pokemonCategories)
                .HasForeignKey(c => c.CategoryId);

            /* ----------------------------------------*/

            modelBuilder.Entity<PokemonOwner>()
                 .HasKey(pc => new { pc.PokemonId, pc.OwnerId });  /* Bu iki ıd'yi birbirine bağladık. */


            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(c => c.PokemonId);

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Owner)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(c => c.OwnerId);






        }
    }
}
