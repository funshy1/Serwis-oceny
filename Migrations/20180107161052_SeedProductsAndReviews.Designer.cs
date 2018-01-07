﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using projekt.Persistence;
using System;

namespace dotnetapp.Migrations
{
    [DbContext(typeof(ServiceDbContext))]
    [Migration("20180107161052_SeedProductsAndReviews")]
    partial class SeedProductsAndReviews
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("projekt.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<float>("Rating");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("projekt.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProductId");

                    b.Property<float>("Rating");

                    b.Property<string>("Text");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("projekt.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("PictureUrl");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("projekt.Models.Product", b =>
                {
                    b.HasOne("projekt.Models.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("projekt.Models.Review", b =>
                {
                    b.HasOne("projekt.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId");

                    b.HasOne("projekt.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
