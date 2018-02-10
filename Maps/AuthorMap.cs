using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Maps
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(80).HasColumnType("varchar(80)");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(160).HasColumnType("varchar(160)");
            builder.HasOne(x => x.User);
            builder.HasMany(x => x.Books);
        }
    }
}