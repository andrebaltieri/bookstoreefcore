using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Maps
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(20).HasColumnType("varchar(120)");
            builder.Property(x => x.ISBN).IsRequired().HasMaxLength(17).HasColumnType("char(17)");
            builder.Property(x => x.ReleaseDate).IsRequired();
            builder.HasMany(x => x.Authors);
        }
    }
}