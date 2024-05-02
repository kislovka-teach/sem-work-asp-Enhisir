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
            .HasMany<Commentary>()
            .WithOne();
        modelBuilder.Entity<Article>()
            .HasIndex(b => b.Title)
            .HasMethod("GIN")
            .IsTsVectorExpressionIndex("english, russian"); // внимательно посмотреть
        
        modelBuilder.Entity<ArticleTag>()
            .HasIndex(x => x.Name)
            .HasMethod("GiST")  // внимательно посмотреть
            .IsTsVectorExpressionIndex("english, russian");
        
        // TODO: добавить индексы
        
        // TODO: добавить теги

        modelBuilder.Entity<Commentary>()
            .HasOne<User>(c => c.Author)
            .WithMany()
            .HasForeignKey(c => c.AuthorId);
        modelBuilder.Entity<Commentary>()
            .HasOne<Commentary>(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.AuthorId);
        
        modelBuilder.Entity<Resume>()
            .HasOne<User>(c => c.User)
            .WithOne(c => c.Resume)
            .HasForeignKey<Resume>(c => c.UserId)
            .HasForeignKey<User>(c => c.ResumeId);
        modelBuilder.Entity<Resume>()
            .HasMany<ResumeTag>(c => c.Tags)
            .WithMany()
            .UsingEntity(e => e.ToTable("resume_tag"));
        
        modelBuilder.Entity<Resume>()
            .HasIndex(b => b.Profession)
            .HasMethod("GiST")  // внимательно посмотреть
            .IsTsVectorExpressionIndex("english, russian");
        
        modelBuilder.Entity<ResumeTag>()
            .HasIndex(t => t.Name)
            .HasMethod("GiST")  // внимательно посмотреть
            .IsTsVectorExpressionIndex("english, russian");

        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();
    }

    public static void PrepareData(this ModelBuilder modelBuilder)
    {
        
    }
}