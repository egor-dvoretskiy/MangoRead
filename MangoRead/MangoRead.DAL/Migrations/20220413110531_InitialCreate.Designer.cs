// <auto-generated />
using System;
using MangoRead.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MangoRead.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220413110531_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MangoRead.Domain.Entities.GenreHolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<int>("ManuscriptId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManuscriptId");

                    b.ToTable("GenreHolder");
                });

            modelBuilder.Entity("MangoRead.Domain.Entities.Manuscript", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Index")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRequireLegalAge")
                        .HasColumnType("bit");

                    b.Property<string>("OriginCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Translator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Index");

                    b.ToTable("Manuscripts");
                });

            modelBuilder.Entity("MangoRead.Domain.Entities.ManuscriptContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManuscriptId")
                        .HasColumnType("int");

                    b.Property<int>("PagesAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManuscriptId")
                        .IsUnique();

                    b.ToTable("ManuscriptContent");
                });

            modelBuilder.Entity("MangoRead.Domain.Entities.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManuscriptContentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManuscriptContentId");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("MangoRead.Domain.Entities.GenreHolder", b =>
                {
                    b.HasOne("MangoRead.Domain.Entities.Manuscript", "Manuscript")
                        .WithMany("Genres")
                        .HasForeignKey("ManuscriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manuscript");
                });

            modelBuilder.Entity("MangoRead.Domain.Entities.ManuscriptContent", b =>
                {
                    b.HasOne("MangoRead.Domain.Entities.Manuscript", "Manuscript")
                        .WithOne("Content")
                        .HasForeignKey("MangoRead.Domain.Entities.ManuscriptContent", "ManuscriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manuscript");
                });

            modelBuilder.Entity("MangoRead.Domain.Entities.Page", b =>
                {
                    b.HasOne("MangoRead.Domain.Entities.ManuscriptContent", "Content")
                        .WithMany("Pages")
                        .HasForeignKey("ManuscriptContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");
                });

            modelBuilder.Entity("MangoRead.Domain.Entities.Manuscript", b =>
                {
                    b.Navigation("Content");

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("MangoRead.Domain.Entities.ManuscriptContent", b =>
                {
                    b.Navigation("Pages");
                });
#pragma warning restore 612, 618
        }
    }
}
