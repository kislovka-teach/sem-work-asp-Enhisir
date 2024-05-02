using Brah.Data.Extensions;
using Brah.Data.Models;
using Brah.Data.Models.Articles;
using Brah.Data.Models.Resumes;
using Brah.Data.Models.Tags;
using Microsoft.EntityFrameworkCore;

namespace Brah.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; } = null!;

    public DbSet<Article> Articles { get; init; } = null!;
    public DbSet<Commentary> Commentaries { get; init; } = null!;
    public DbSet<ArticleTag> ArticleTags { get; init; } = null!;
    public DbSet<Topic> Topics { get; init; } = null!;

    public DbSet<Resume> Resumes { get; init; } = null!;
    public DbSet<ResumeTag> ResumeTags { get; init; } = null!;
    public DbSet<WorkPlace> WorkPlaces { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.PrepareEntities();
        modelBuilder.PrepareData();
    }
}