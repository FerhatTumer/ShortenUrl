﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SHORTURL.Infrastructure;

#nullable disable

namespace SHORTURL.Migrations
{
    [DbContext(typeof(UrlDbContext))]
    partial class UrlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SHORTURL.Domain.Entities.UrlEntry", b =>
                {
                    b.Property<string>("ShortUrl")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("SHORTURL");

                    b.Property<string>("LongUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShortUrl");

                    b.ToTable("TB_URL_ENTRIES", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
