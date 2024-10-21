using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MySafeNote.Core;
using MySafeNote.DataAccess.EntityConfigurations;

namespace MySafeNote.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new NoteEntityConfiguration());

            //var userId1 = 1;
            //var userId2 = 2;

            //modelBuilder.Entity<User>().HasData(
            //    new User { Id = 1, Email = "owner1@somemail.ru", PasswordHash = "asghal7eteysjgpoih" },
            //    new User { Id = 2, Email = "owner2@somemail.ru", PasswordHash = "gdhajlghaslfsfasfa" }
            //);
            //modelBuilder.Entity<Note>().HasData(
            //    new Note { Id = 1, UserId = userId1, Number = 1, Title = "Заметка пользователя 1", BodyLink = Guid.NewGuid(), NotePasswordHash = "", CreateDate = DateTime.Now, LastChangeDate = DateTime.Now },
            //    new Note { Id = 2, UserId = userId2, Number = 1, Title = "Заметка пользователя 2", BodyLink = Guid.NewGuid(), NotePasswordHash = "", CreateDate = DateTime.Now, LastChangeDate = DateTime.Now }
            //);

            base.OnModelCreating(modelBuilder);
        }
    }
}
