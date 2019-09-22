using ContactsManager.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsManager.Infrastructures.Dal
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.ContactId);
            builder.Property(x => x.FullName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15).HasColumnType("varchar(15)");
            builder.Property(x => x.Mobile).HasMaxLength(11).HasColumnType("varchar(11)"); ;

        }
    }
}
