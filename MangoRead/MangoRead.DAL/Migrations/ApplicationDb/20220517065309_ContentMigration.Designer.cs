﻿// <auto-generated />
using System;
using MangoRead.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MangoRead.DAL.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220517065309_ContentMigration")]
    partial class ContentMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MangoRead.Domain.Models.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VolumeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VolumeId");

                    b.ToTable("Chapter");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.GenreHolder", b =>
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

            modelBuilder.Entity("MangoRead.Domain.Models.Manuscript", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ApprovalStatus")
                        .HasColumnType("int");

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

                    b.Property<byte[]>("TitleImage")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

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

            modelBuilder.Entity("MangoRead.Domain.Models.ManuscriptContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ApprovalStatus")
                        .HasColumnType("int");

                    b.Property<string>("FolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManuscriptId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManuscriptId")
                        .IsUnique();

                    b.ToTable("ManuscriptContent");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.ManuscriptReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ApprovalStatus")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManuscriptId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ManuscriptId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChapterId")
                        .HasColumnType("int");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.Volume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ManuscriptContentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManuscriptContentId");

                    b.ToTable("Volume");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.Chapter", b =>
                {
                    b.HasOne("MangoRead.Domain.Models.Volume", "Volume")
                        .WithMany("Chapters")
                        .HasForeignKey("VolumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Volume");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.Comment", b =>
                {
                    b.HasOne("MangoRead.Domain.Models.Page", "Page")
                        .WithMany("Comments")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Page");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.GenreHolder", b =>
                {
                    b.HasOne("MangoRead.Domain.Models.Manuscript", "Manuscript")
                        .WithMany("Genres")
                        .HasForeignKey("ManuscriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manuscript");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.ManuscriptContent", b =>
                {
                    b.HasOne("MangoRead.Domain.Models.Manuscript", "Manuscript")
                        .WithOne("Content")
                        .HasForeignKey("MangoRead.Domain.Models.ManuscriptContent", "ManuscriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manuscript");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.ManuscriptReview", b =>
                {
                    b.HasOne("MangoRead.Domain.Models.Manuscript", "Manuscript")
                        .WithMany("Reviews")
                        .HasForeignKey("ManuscriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manuscript");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.Page", b =>
                {
                    b.HasOne("MangoRead.Domain.Models.Chapter", "Chapter")
                        .WithMany("Pages")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.Volume", b =>
                {
                    b.HasOne("MangoRead.Domain.Models.ManuscriptContent", "ManuscriptContent")
                        .WithMany("Volumes")
                        .HasForeignKey("ManuscriptContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManuscriptContent");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.Chapter", b =>
                {
                    b.Navigation("Pages");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.Manuscript", b =>
                {
                    b.Navigation("Content");

                    b.Navigation("Genres");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.ManuscriptContent", b =>
                {
                    b.Navigation("Volumes");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.Page", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("MangoRead.Domain.Models.Volume", b =>
                {
                    b.Navigation("Chapters");
                });
#pragma warning restore 612, 618
        }
    }
}
