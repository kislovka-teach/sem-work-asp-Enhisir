﻿// <auto-generated />
using System;
using Brah.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Brah.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pg_trgm");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Brah.Data.Models.Articles.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("Karma")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimePosted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TopicId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Title");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Title"), "GIN");
                    NpgsqlIndexBuilderExtensions.HasOperators(b.HasIndex("Title"), new[] { "gin_trgm_ops" });

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Karma = 15,
                            Text = "example example example example example example example example example example example example example example example example example example example example example example example example example",
                            TimePosted = new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                            Title = "Text example",
                            TopicId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Karma = 15,
                            Text = "example example example example example example example example example example example example example example example example example example example example example example example example example",
                            TimePosted = new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                            Title = "Text example 2",
                            TopicId = 1
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            Karma = 15,
                            Text = "example example example example example example example example example example example example example example example example example example example example example example example example example",
                            TimePosted = new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Title = "Text example 3",
                            TopicId = 1
                        });
                });

            modelBuilder.Entity("Brah.Data.Models.Articles.Commentary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("integer");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimePosted")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ParentId");

                    b.ToTable("Commentaries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleId = 1,
                            AuthorId = 1,
                            Text = "Как дела? Пока не родила",
                            TimePosted = new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            ArticleId = 1,
                            AuthorId = 1,
                            ParentId = 1,
                            Text = "Как дела? Пока не родила",
                            TimePosted = new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            ArticleId = 1,
                            AuthorId = 1,
                            ParentId = 2,
                            Text = "Как дела? Пока не родила",
                            TimePosted = new DateTime(2024, 5, 2, 0, 1, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 4,
                            ArticleId = 1,
                            AuthorId = 1,
                            ParentId = 1,
                            Text = "Как дела? Пока не родила",
                            TimePosted = new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 5,
                            ArticleId = 1,
                            AuthorId = 1,
                            ParentId = 2,
                            Text = "Как дела? Пока не родила",
                            TimePosted = new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("Brah.Data.Models.Articles.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Разработка"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Администрирование"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Дизайн"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Менеждмент"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Маркетинг"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Разное"
                        });
                });

            modelBuilder.Entity("Brah.Data.Models.MtM.ArticleTagToArticle", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("integer");

                    b.Property<int>("ArticleTagId")
                        .HasColumnType("integer");

                    b.HasKey("ArticleId", "ArticleTagId");

                    b.HasIndex("ArticleTagId");

                    b.ToTable("ArticleTagToArticle");
                });

            modelBuilder.Entity("Brah.Data.Models.MtM.ResumeTagToResume", b =>
                {
                    b.Property<int>("ResumeId")
                        .HasColumnType("integer");

                    b.Property<int>("ResumeTagId")
                        .HasColumnType("integer");

                    b.HasKey("ResumeId", "ResumeTagId");

                    b.HasIndex("ResumeTagId");

                    b.ToTable("ResumeTagToResume");
                });

            modelBuilder.Entity("Brah.Data.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Brah.Data.Models.Resumes.Resume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("About")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("Email")
                        .HasMaxLength(320)
                        .HasColumnType("character varying(320)");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<int>("LeftSalaryBorder")
                        .HasColumnType("integer");

                    b.Property<bool>("LookingForWork")
                        .HasColumnType("boolean");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("RightSalaryBorder")
                        .HasColumnType("integer");

                    b.Property<string>("Telegram")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Profession");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Profession"), "GIN");
                    NpgsqlIndexBuilderExtensions.HasOperators(b.HasIndex("Profession"), new[] { "gin_trgm_ops" });

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Resumes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            About = "ddfsdgdfdsf dsfdsfsdfs dfdsfsdfsd fdsfdsfsdfsdddfsdgdfdsf dsfdsfsdfs dfdsfsdfsd fdsfdsfsdfsdddfsdgdfdsf dsfdsfsdfs dfdsfsdfsd fdsfdsfsdfsdddfsdgdfdsf dsfdsfsdfs dfdsfsdfsd fdsfdsfsdfsd",
                            Grade = 0,
                            LeftSalaryBorder = 100000,
                            LookingForWork = true,
                            Profession = "Малолетний дебил",
                            RightSalaryBorder = 150000,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Brah.Data.Models.Resumes.WorkPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateBegin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ResumeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("WorkPlaces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "Министрество не твоих собачьих дел",
                            DateBegin = new DateTime(2024, 5, 2, 21, 0, 0, 0, DateTimeKind.Utc),
                            Description = "См. название",
                            Grade = 2,
                            Profession = "Какой-то мужик",
                            ResumeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CompanyName = "ИП Макима",
                            DateBegin = new DateTime(2022, 5, 2, 21, 0, 0, 0, DateTimeKind.Utc),
                            DateEnd = new DateTime(2023, 5, 2, 21, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Кусал за ногу",
                            Grade = 3,
                            Profession = "Собачка",
                            ResumeId = 1
                        });
                });

            modelBuilder.Entity("Brah.Data.Models.Subscription", b =>
                {
                    b.Property<int>("ReaderId")
                        .HasColumnType("integer");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.HasKey("ReaderId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Brah.Data.Models.Tags.ArticleTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Name"), "GIN");
                    NpgsqlIndexBuilderExtensions.HasOperators(b.HasIndex("Name"), new[] { "gin_trgm_ops" });

                    b.HasIndex(new[] { "Name" }, "unique_article_tag_constraint")
                        .IsUnique();

                    b.ToTable("ArticleTags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Different 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Different 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Different 3"
                        });
                });

            modelBuilder.Entity("Brah.Data.Models.Tags.ResumeTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Name"), "GIN");
                    NpgsqlIndexBuilderExtensions.HasOperators(b.HasIndex("Name"), new[] { "gin_trgm_ops" });

                    b.HasIndex(new[] { "Name" }, "unique_resume_tag_constraint")
                        .IsUnique();

                    b.ToTable("ResumeTags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Backend"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Frontend"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Full-Stack"
                        });
                });

            modelBuilder.Entity("Brah.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarLink")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("PasswordHashed")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvatarLink = "https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd",
                            FirstName = "Nikolay",
                            LastName = "Rerich",
                            PasswordHashed = "DefaultPassword",
                            Role = 0,
                            UserName = "DeadWeight47"
                        });
                });

            modelBuilder.Entity("Brah.Data.Models.Articles.Article", b =>
                {
                    b.HasOne("Brah.Data.Models.Articles.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("Brah.Data.Models.User", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Brah.Data.Models.Articles.Commentary", b =>
                {
                    b.HasOne("Brah.Data.Models.Articles.Article", "Article")
                        .WithMany("Commentaries")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Brah.Data.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Brah.Data.Models.Articles.Commentary", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Article");

                    b.Navigation("Author");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Brah.Data.Models.MtM.ArticleTagToArticle", b =>
                {
                    b.HasOne("Brah.Data.Models.Articles.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Brah.Data.Models.Tags.ArticleTag", null)
                        .WithMany()
                        .HasForeignKey("ArticleTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Brah.Data.Models.MtM.ResumeTagToResume", b =>
                {
                    b.HasOne("Brah.Data.Models.Resumes.Resume", null)
                        .WithMany()
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Brah.Data.Models.Tags.ResumeTag", null)
                        .WithMany()
                        .HasForeignKey("ResumeTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Brah.Data.Models.Notification", b =>
                {
                    b.HasOne("Brah.Data.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Brah.Data.Models.Resumes.Resume", b =>
                {
                    b.HasOne("Brah.Data.Models.User", "User")
                        .WithOne("Resume")
                        .HasForeignKey("Brah.Data.Models.Resumes.Resume", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Brah.Data.Models.Resumes.WorkPlace", b =>
                {
                    b.HasOne("Brah.Data.Models.Resumes.Resume", "Resume")
                        .WithMany("WorkPlaces")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("Brah.Data.Models.Subscription", b =>
                {
                    b.HasOne("Brah.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Brah.Data.Models.User", null)
                        .WithMany("Subscriptions")
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Brah.Data.Models.Articles.Article", b =>
                {
                    b.Navigation("Commentaries");
                });

            modelBuilder.Entity("Brah.Data.Models.Articles.Commentary", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Brah.Data.Models.Resumes.Resume", b =>
                {
                    b.Navigation("WorkPlaces");
                });

            modelBuilder.Entity("Brah.Data.Models.User", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Resume");

                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
