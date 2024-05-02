using Brah.Data.Enums;
using Brah.Data.Models;
using Brah.Data.Models.Articles;
using Brah.Data.Models.Resumes;
using Brah.Data.Models.Tags;
using Microsoft.EntityFrameworkCore;

namespace Brah.Data.Extensions;

public static class ModelBuilderExtension
{
    public static void PrepareEntities(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
            .HasOne<User>(a => a.Author)
            .WithMany(u => u.Articles)
            .HasForeignKey(a => a.AuthorId);
        modelBuilder.Entity<Article>()
            .HasMany<ArticleTag>(a => a.Tags)
            .WithMany()
            .UsingEntity(e => e.ToTable("article_tag"));
        modelBuilder.Entity<Article>()
            .HasOne<Topic>(a => a.Topic)
            .WithMany()
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<Article>()
            .HasIndex(b => b.Title)
            .HasMethod("GIN")
            .IsTsVectorExpressionIndex("russian"); // добавить индекс для английского

        modelBuilder.Entity<ArticleTag>()
            .HasIndex(x => x.Name)
            .HasMethod("GiST")
            .IsTsVectorExpressionIndex("russian");

        modelBuilder.Entity<Commentary>()
            .HasOne<User>(c => c.Author)
            .WithMany()
            .HasForeignKey(c => c.AuthorId);
        modelBuilder.Entity<Commentary>()
            .HasOne<Commentary>(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.AuthorId);
        modelBuilder.Entity<Commentary>()
            .HasOne<Commentary>(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.AuthorId);
        modelBuilder.Entity<Commentary>()
            .HasOne<Article>(c => c.Article)
            .WithMany(a => a.Commentaries)
            .HasForeignKey(c => c.ArticleId);

        modelBuilder.Entity<Resume>()
            .HasOne<User>(c => c.User)
            .WithOne(c => c.Resume)
            .HasForeignKey<Resume>(r => r.UserId);
        modelBuilder.Entity<Resume>()
            .HasMany<ResumeTag>(c => c.Tags)
            .WithMany()
            .UsingEntity(e => e.ToTable("resume_tag"));
        modelBuilder.Entity<Resume>()
            .HasMany<WorkPlace>(c => c.WorkPlaces)
            .WithOne(w => w.Resume)
            .HasForeignKey(w => w.ResumeId);
        modelBuilder.Entity<Resume>()
            .HasIndex(b => b.Profession)
            .HasMethod("GIN")
            .IsTsVectorExpressionIndex("russian");

        modelBuilder.Entity<ResumeTag>()
            .HasIndex(t => t.Name)
            .HasMethod("GiST")
            .IsTsVectorExpressionIndex("russian");

        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();
    }

    public static void PrepareData(this ModelBuilder modelBuilder)
    {
        var topics = new List<Topic>
        {
            new() { Id = 1, Name = "Разработка" },
            new() { Id = 2, Name = "Администрирование" },
            new() { Id = 3, Name = "Дизайн" },
            new() { Id = 4, Name = "Менеждмент" },
            new() { Id = 5, Name = "Маркетинг" },
            new() { Id = 6, Name = "Разное" },
        };
        modelBuilder.Entity<Topic>().HasData(topics);

        var articlesAuthor = new User
        {
            Id = 1,
            UserName = "DeadWeight47",
            FirstName = "Nikolay",
            LastName = "Rerich",
            AvatarLink =
                "https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg"
                + "?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd",
            PasswordHashed = "DefaultPassword",
            Role = Role.User
        };

        modelBuilder.Entity<User>()
            .HasData(articlesAuthor);

        var tags = new List<ArticleTag>()
        {
            new() { Id = 1, Name = "Different 1" },
            new() { Id = 2, Name = "Different 2" },
            new() { Id = 3, Name = "Different 3" },
        };
        modelBuilder.Entity<ArticleTag>()
            .HasData(tags);

        var articles = new List<Article>()
        {
            new()
            {
                Id = 1,
                AuthorId = articlesAuthor.Id,
                TopicId = topics[0].Id,
                TimePosted = DateTime.UtcNow,
                Karma = 15,
                Title = "Text example",
                Text = "example example example example example"
                       + " example example example example example"
                       + " example example example example example"
                       + " example example example example example"
                       + " example example example example example"
            },
            new()
            {
                Id = 2,
                AuthorId = articlesAuthor.Id,
                TopicId = topics[0].Id,
                TimePosted = DateTime.UtcNow,
                Karma = 15,
                Title = "Text example 2",
                Text = "example example example example example"
                       + " example example example example example"
                       + " example example example example example"
                       + " example example example example example"
                       + " example example example example example"
            },
            new()
            {
                Id = 3,
                AuthorId = articlesAuthor.Id,
                TopicId = topics[0].Id,
                TimePosted = DateTime.UtcNow,
                Karma = 15,
                Title = "Text example 3",
                Text = "example example example example example"
                       + " example example example example example"
                       + " example example example example example"
                       + " example example example example example"
                       + " example example example example example"
            }
        };
        modelBuilder.Entity<Article>().HasData(articles);

        /*modelBuilder.Entity<Article>()
            .HasMany<ArticleTag>()
            .WithMany()
            .UsingEntity(j => j.ToTable("article_tag"))
            .HasData(
                [
                    new { ArticleId = 1, ArticleTagId = 1 },
                    new { ArticleId = 1, ArticleTagId = 2 },
                    new { ArticleId = 1, ArticleTagId = 3 },
                    new { ArticleId = 1, ArticleTagId = 4 }
                ]
            );*/
    }
}