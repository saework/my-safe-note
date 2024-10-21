﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySafeNote.Core;

namespace MySafeNote.DataAccess.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(r => r.Id);
            //builder.HasIndex(r => r.Email);
            builder.Property(r => r.Email).IsRequired().HasMaxLength(256);
        }
    }
}
