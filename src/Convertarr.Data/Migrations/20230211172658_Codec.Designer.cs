﻿// <auto-generated />
using Convertarr.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Convertarr.Data.Migrations
{
    [DbContext(typeof(ConvertarrContext))]
    [Migration("20230211172658_Codec")]
    partial class Codec
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Convertarr.Data.MediaFile", b =>
                {
                    b.Property<int>("MediaFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MediaInfoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MediaFileId");

                    b.HasIndex("MediaInfoId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Convertarr.Data.Models.MediaInfo", b =>
                {
                    b.Property<int>("MediaInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codec")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MediaInfoId");

                    b.ToTable("MediaInfo");
                });

            modelBuilder.Entity("Convertarr.Data.MediaFile", b =>
                {
                    b.HasOne("Convertarr.Data.Models.MediaInfo", "MediaInfo")
                        .WithMany()
                        .HasForeignKey("MediaInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MediaInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
