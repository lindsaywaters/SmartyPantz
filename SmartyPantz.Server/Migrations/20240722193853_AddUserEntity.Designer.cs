﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartyPantz.Server.Models;

#nullable disable

namespace SmartyPantz.Server.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240722193853_AddUserEntity")]
    partial class AddUserEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SmartyPantz.Server.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Learn to recognize and write letters of the alphabet",
                            IsChecked = false,
                            Title = "isLetters"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Learn to recognize and write numbers 1-20",
                            IsChecked = false,
                            Title = "isNumbers"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Learn to count objects up to 20",
                            IsChecked = false,
                            Title = "isCounting"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Learn to recognize basic shapes (circle, square, triangle, rectangle)",
                            IsChecked = false,
                            Title = "isShapes"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Learn to identify colors",
                            IsChecked = false,
                            Title = "isColors"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Develop fine motor skills through activities such as cutting with scissors, coloring, and tracing",
                            IsChecked = false,
                            Title = "isFineMotor"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Learn to recognize and write their own name",
                            IsChecked = false,
                            Title = "isNameWriting"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Learn to follow simple instructions",
                            IsChecked = false,
                            Title = "isInstructions"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Learn to participate in group activities and share with others",
                            IsChecked = false,
                            Title = "isGroupActivities"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Develop basic social skills such as taking turns and listening to others",
                            IsChecked = false,
                            Title = "isSocialSkills"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Develop independence in tasks like dressing themselves and cleaning up after activities",
                            IsChecked = false,
                            Title = "isIndependence"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Build vocabulary and language skills through reading and conversation",
                            IsChecked = false,
                            Title = "isVocabulary"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Develop basic math skills such as understanding basic addition and subtraction concepts",
                            IsChecked = false,
                            Title = "isMath"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Develop pre-reading skills such as recognizing rhyming words and understanding basic sight words",
                            IsChecked = false,
                            Title = "isPreReading"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Develop basic problem-solving skills through puzzles and simple games",
                            IsChecked = false,
                            Title = "isProblemSolving"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Develop gross motor skills through activities such as running, jumping, and climbing",
                            IsChecked = false,
                            Title = "isGrossMotor"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Practice good hygiene habits such as washing hands and covering coughs/sneezes",
                            IsChecked = false,
                            Title = "isHygiene"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Understand basic concepts of time such as morning, afternoon, and evening",
                            IsChecked = false,
                            Title = "isTime"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Engage in imaginative play and creativity",
                            IsChecked = false,
                            Title = "isCreativity"
                        });
                });

            modelBuilder.Entity("SmartyPantz.Server.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ChildsAge")
                        .HasColumnType("int");

                    b.Property<string>("ChildsName")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
