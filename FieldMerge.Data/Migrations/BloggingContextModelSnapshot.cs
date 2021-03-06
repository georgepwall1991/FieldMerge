// <auto-generated />
using FieldMerge.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FieldMerge.Data.Migrations
{
    [DbContext(typeof(FieldCodeContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("FieldMerge.Data.Models.FieldCodePattern", b =>
                {
                    b.Property<int>("PatternId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PatternFrom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PatternTo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PatternId");

                    b.ToTable("FieldCodePatterns");
                });
#pragma warning restore 612, 618
        }
    }
}
