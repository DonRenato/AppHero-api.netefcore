﻿// <auto-generated />
using System;
using EFCore.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppHero.Migrations
{
    [DbContext(typeof(HeroContext))]
    [Migration("20200822025716_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppHero.Model.Battle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("beginDate");

                    b.Property<DateTime>("endDate");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("AppHero.Model.Hero", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("battleId");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("battleId");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("AppHero.Model.Weapon", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("heroId");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("heroId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("AppHero.Model.Hero", b =>
                {
                    b.HasOne("AppHero.Model.Battle", "battle")
                        .WithMany()
                        .HasForeignKey("battleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppHero.Model.Weapon", b =>
                {
                    b.HasOne("AppHero.Model.Hero", "hero")
                        .WithMany()
                        .HasForeignKey("heroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
