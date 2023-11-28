﻿// <auto-generated />
using System;
using HomeLibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeLibAPI.Migrations
{
    [DbContext(typeof(HomeLibraryDbContext))]
    partial class HomeLibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeLibraryAPI.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("HomeLibraryAPI.Entities.Keyword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Keyword");
                });

            modelBuilder.Entity("HomeLibraryAPI.Entities.LibraryElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("LibraryElement");
                });

            modelBuilder.Entity("HomeLibraryAPI.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("HomeLibraryAPI.Entities.RecordLabel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecordLabels");
                });

            modelBuilder.Entity("KeywordLibraryElement", b =>
                {
                    b.Property<int>("KeywordsId")
                        .HasColumnType("int");

                    b.Property<int>("LibraryElementsId")
                        .HasColumnType("int");

                    b.HasKey("KeywordsId", "LibraryElementsId");

                    b.HasIndex("LibraryElementsId");

                    b.ToTable("KeywordLibraryElement");
                });

            modelBuilder.Entity("HomeLibraryAPI.Entities.Book", b =>
                {
                    b.HasBaseType("HomeLibraryAPI.Entities.LibraryElement");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("TableOfContents")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("HomeLibraryAPI.Entities.Magazine", b =>
                {
                    b.HasBaseType("HomeLibraryAPI.Entities.LibraryElement");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("TableOfContents")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("PublisherId");

                    b.ToTable("Magazines");
                });

            modelBuilder.Entity("HomeLibraryAPI.Entities.Multimedia", b =>
                {
                    b.HasBaseType("HomeLibraryAPI.Entities.LibraryElement");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("RecordLabelId")
                        .HasColumnType("int");

                    b.Property<string>("RecordsList")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("RecordLabelId");

                    b.ToTable("Multimedias");
                });

            modelBuilder.Entity("HomeLibraryAPI.Entities.LibraryElement", b =>
                {
                    b.HasOne("HomeLibraryAPI.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("KeywordLibraryElement", b =>
                {
                    b.HasOne("HomeLibraryAPI.Entities.Keyword", null)
                        .WithMany()
                        .HasForeignKey("KeywordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeLibraryAPI.Entities.LibraryElement", null)
                        .WithMany()
                        .HasForeignKey("LibraryElementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeLibraryAPI.Entities.Book", b =>
                {
                    b.HasOne("HomeLibraryAPI.Entities.LibraryElement", null)
                        .WithOne()
                        .HasForeignKey("HomeLibraryAPI.Entities.Book", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("HomeLibraryAPI.Entities.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("HomeLibraryAPI.Entities.Magazine", b =>
                {
                    b.HasOne("HomeLibraryAPI.Entities.LibraryElement", null)
                        .WithOne()
                        .HasForeignKey("HomeLibraryAPI.Entities.Magazine", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("HomeLibraryAPI.Entities.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("HomeLibraryAPI.Entities.Multimedia", b =>
                {
                    b.HasOne("HomeLibraryAPI.Entities.LibraryElement", null)
                        .WithOne()
                        .HasForeignKey("HomeLibraryAPI.Entities.Multimedia", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("HomeLibraryAPI.Entities.RecordLabel", "RecordLabel")
                        .WithMany()
                        .HasForeignKey("RecordLabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecordLabel");
                });
#pragma warning restore 612, 618
        }
    }
}
