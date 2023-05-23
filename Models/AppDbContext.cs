using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using TrainingsAppApi.Configuration;
using TrainingsAppApi.Entities;
using TrainingsAppApi.Models.Entities;

namespace TrainingsAppApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<CourseEntity> Courses { get; set; }

        



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql("Server=db4free.net;Port=3306;Database=trainingsapp;Uid=matrix153;Password=abcd123!;", 
                ServerVersion.AutoDetect("Server=db4free.net;Port=3306;Database=trainingsapp;Uid=matrix153;Password=abcd123!;"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().HasKey(e => e.Id);
            modelBuilder.Entity<UserEntity>().Property(e => e.Username).IsRequired(true);
            modelBuilder.Entity<UserEntity>().Property(e => e.FirstName).IsRequired(true);
            modelBuilder.Entity<UserEntity>().Property(e => e.LastName).IsRequired(true);
            modelBuilder.Entity<UserEntity>().Property(e => e.Email).IsRequired(true);
            modelBuilder.Entity<UserEntity>().Property(e => e.Password).IsRequired(true);
            modelBuilder.Entity<UserEntity>().Property(e => e.IsTeacher).IsRequired(true);
            modelBuilder.Entity<UserEntity>().Property(e => e.Country).IsRequired(true);
            modelBuilder.Entity<UserEntity>().Property(e => e.City).IsRequired(true);
            modelBuilder.Entity<UserEntity>().Property(e => e.Street).IsRequired(true);


            modelBuilder.Entity<CourseEntity>().HasKey(e => e.Id);
            modelBuilder.Entity<UserEntity>().HasMany(e => e.Courses).WithMany(e=>e.Users);

            


        }
    }
}
