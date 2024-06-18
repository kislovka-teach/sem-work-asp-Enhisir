using System.Security.Claims;
using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Requests.Article;
using Brah.BL.Exceptions;
using Brah.Data.Abstractions;
using Brah.Data.Models.Articles;
using Brah.Data.Models.MtM;
using Brah.Data.Models.Tags;

namespace Brah.BL.Services;

public class ManageArticleService(
    IMapper mapper,
    IHasTransactions transactionManager,
    IUserRepository userRepository,
    IRepository<Article> articleRepository,
    IRepository<ArticleTagToArticle> tagRelationsRepository) : IManageArticleService
{
    public async Task CreateArticleAsync(ClaimsIdentity identity, CreateArticleRequestDto requestDto)
    {
        var user = await userRepository
            .GetSingleOrDefault(t => t.UserName.Equals(identity.Name));

        if (user == null) throw new NotFoundException();

        var article = mapper.Map<Article>(requestDto);
        article.AuthorId = user.Id;

        var tags = mapper.Map<List<ArticleTag>>(requestDto.Tags);

        try
        {
            transactionManager.BeginTransaction();
            var realArticle = await articleRepository.AddAsync(article);
            await tagRelationsRepository.AddRangeAsync(
                tags.Select(
                    tag => new ArticleTagToArticle()
                    {
                        ArticleId = realArticle.Id,
                        ArticleTagId = tag.Id,
                    }));
            transactionManager.CommitTransaction();
        }
        catch
        {
            transactionManager.RollbackTransaction();
            throw;
        }
    }

    public async Task UpdateArticleAsync(ClaimsIdentity identity, UpdateArticleRequestDto requestDto)
    {
        var user = await userRepository
            .GetSingleOrDefault(t => t.UserName.Equals(identity.Name));
        var article = await articleRepository
            .GetSingleOrDefault(t => t.Id == requestDto.Id);

        if (user == null || article == null) throw new NotFoundException();
        if (article.AuthorId != user.Id) throw new NotFoundException();


        transactionManager.BeginTransaction();
        try
        {
            var newArticle = mapper.Map(requestDto, article);

            var newTags = mapper.Map<List<ArticleTag>>(requestDto.Tags);
            var countIds = new Dictionary<int, int>();
            foreach (var id in newTags.Select(t => t.Id))
            {
                countIds.TryAdd(id, 0);
                countIds[id]++;
            }

            if (countIds.Any(pair => pair.Value > 1)) throw new InvalidOperationException();


            foreach (var tag in newArticle.Tags)
            {
                await tagRelationsRepository.RemoveAsync(
                    new ArticleTagToArticle()
                    {
                        ArticleId = article.Id,
                        ArticleTagId = tag.Id,
                    });
            }

            newArticle.Tags.Clear();
            await tagRelationsRepository.AddRangeAsync(
                newTags.Select(
                    tag => new ArticleTagToArticle()
                    {
                        ArticleId = article.Id,
                        ArticleTagId = tag.Id,
                    }));
            await articleRepository.UpdateAsync(newArticle);
            transactionManager.CommitTransaction();
        }
        catch
        {
            transactionManager.RollbackTransaction();
            throw;
        }
    }
}