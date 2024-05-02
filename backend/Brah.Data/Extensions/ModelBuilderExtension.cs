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

    }
}