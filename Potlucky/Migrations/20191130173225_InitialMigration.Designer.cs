﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Potlucky.Models;

namespace Potlucky.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191130173225_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Potlucky.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("MessageText");

                    b.Property<int?>("SenderUserId");

                    b.HasKey("MessageId");

                    b.HasIndex("SenderUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Potlucky.Models.Reply", b =>
                {
                    b.Property<int>("ReplyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int?>("MessageId");

                    b.Property<string>("MessageText");

                    b.Property<int?>("SenderUserId");

                    b.HasKey("ReplyId");

                    b.HasIndex("MessageId");

                    b.HasIndex("SenderUserId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("Potlucky.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FavoriteDish");

                    b.Property<string>("FirstName");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsFeaturedCook");

                    b.Property<string>("LastName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Potlucky.Models.Message", b =>
                {
                    b.HasOne("Potlucky.Models.User", "Sender")
                        .WithMany("Messages")
                        .HasForeignKey("SenderUserId");
                });

            modelBuilder.Entity("Potlucky.Models.Reply", b =>
                {
                    b.HasOne("Potlucky.Models.Message")
                        .WithMany("Replies")
                        .HasForeignKey("MessageId");

                    b.HasOne("Potlucky.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
