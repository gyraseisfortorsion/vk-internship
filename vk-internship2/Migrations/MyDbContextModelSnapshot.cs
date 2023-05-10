﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using vk_internship2.Data;

#nullable disable

namespace vk_internship2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("vk_internship2.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("login")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<int?>("user_group_idid")
                        .HasColumnType("integer");

                    b.Property<int?>("user_state_idid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("user_group_idid");

                    b.HasIndex("user_state_idid");

                    b.ToTable("user");
                });

            modelBuilder.Entity("vk_internship2.Models.User_group", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("code")
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("user_groups");
                });

            modelBuilder.Entity("vk_internship2.Models.User_state", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("code")
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("user_states");
                });

            modelBuilder.Entity("vk_internship2.Models.User", b =>
                {
                    b.HasOne("vk_internship2.Models.User_group", "user_group_id")
                        .WithMany()
                        .HasForeignKey("user_group_idid");

                    b.HasOne("vk_internship2.Models.User_state", "user_state_id")
                        .WithMany()
                        .HasForeignKey("user_state_idid");

                    b.Navigation("user_group_id");

                    b.Navigation("user_state_id");
                });
#pragma warning restore 612, 618
        }
    }
}