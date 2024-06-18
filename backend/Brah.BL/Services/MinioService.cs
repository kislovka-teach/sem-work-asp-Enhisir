using Brah.BL.Abstractions;
using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;

namespace Brah.BL.Services;

public class MinioService(IMinioClient minioClient) : IMinioService
{
    private const string ImageBucket = "image";
    private const int DefaultExpiry = 604800;

    public async Task<string> SaveImage(IFormFile image)
    {
        await TryCreateBucketAsync(ImageBucket);

        var name = Path.GetFileNameWithoutExtension(image.FileName)
            .Replace(' ', '_').ToLower();
        var extension = Path.GetExtension(image.FileName);
        var imageId = $"{name}{Guid.NewGuid()}{extension}";
        await using var imageStream = image.OpenReadStream();

        await minioClient.PutObjectAsync(
                new PutObjectArgs()
                    .WithBucket(ImageBucket)
                    .WithObject(imageId)
                    .WithObjectSize(imageStream.Length)
                    .WithStreamData(imageStream))
            .ConfigureAwait(false);
        return imageId;
    }

    public async Task DeleteImage(string imageId)
    {
        await TryCreateBucketAsync(ImageBucket);

        await minioClient.RemoveObjectAsync(
                new RemoveObjectArgs()
                    .WithBucket(ImageBucket)
                    .WithObject(imageId))
            .ConfigureAwait(false);
    }

    public async Task<string> GetImageAsync(string imageId)
    {
        await TryCreateBucketAsync(ImageBucket);

        return await minioClient
            .PresignedGetObjectAsync(
                new PresignedGetObjectArgs()
                    .WithBucket(ImageBucket)
                    .WithExpiry(DefaultExpiry)
                    .WithObject(imageId))
            .ConfigureAwait(false);
    }

    private async Task TryCreateBucketAsync(string bucketName)
    {
        var beArgs = new BucketExistsArgs()
            .WithBucket(bucketName);
        var found = await minioClient
            .BucketExistsAsync(beArgs)
            .ConfigureAwait(false);
        if (!found)
        {
            var mbArgs = new MakeBucketArgs()
                .WithBucket(bucketName);
            await minioClient
                .MakeBucketAsync(mbArgs)
                .ConfigureAwait(false);
        }
    }
}