using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MySafeNote.Core;

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
            var userId1 = 1;
            var userId2 = 2;

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "owner1@somemail.ru", PasswordHash = "asghal7eteysjgpoih" },
                new User { Id = 2, Email = "owner2@somemail.ru", PasswordHash = "gdhajlghaslfsfasfa" }
            //new User { Id = Guid.Parse("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"), Email = "owner1@somemail.ru", PasswordHash = "asghal7eteysjgpoih" },
            //new User { Id = Guid.Parse("551533d6-d8d5-4a11-7c7b-eb9f14e1a32p"), Email = "owner2@somemail.ru", PasswordHash = "gdhajlghaslfsfasfa" }
            );
            modelBuilder.Entity<Note>().HasData(
                new Note { Id = 1, UserId = userId1, Number = 1, Title = "Заметка пользователя 1", BodyLink = Guid.NewGuid(), NotePasswordHash = "", CreateDate = DateTime.Now, LastChangeDate = DateTime.Now },
                new Note { Id = 2, UserId = userId2, Number = 1, Title = "Заметка пользователя 2", BodyLink = Guid.NewGuid(), NotePasswordHash = "", CreateDate = DateTime.Now, LastChangeDate = DateTime.Now }
            //new Note { Id = Guid.Parse("751533d5-d8d5-4a11-9c7b-eb9f14e1a32u"), UserId = Guid.Parse("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"), Number = 1, Title = "Заметка пользователя 1", BodyLink = Guid.Parse("888533d5-d8d5-4a11-9c7b-eb9f14e1a32r"), NotePassword = "", CreateDate = DateTime.Now, LastChangeDate = DateTime.Now },
            //new Note { Id = Guid.Parse("851533d6-d8d5-4a11-7c7b-eb9f14e1a32g"), UserId = Guid.Parse("551533d6-d8d5-4a11-7c7b-eb9f14e1a32p"), Number = 1, Title = "Заметка пользователя 2", BodyLink = Guid.Parse("999533d5-d8d5-4a11-9c7b-eb9f14e1a32e"), NotePassword = "", CreateDate = DateTime.Now, LastChangeDate = DateTime.Now }
            );
        }
    }
}
