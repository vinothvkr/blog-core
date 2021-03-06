﻿using BlogCore.Core.Helpers;
using BlogCore.PostContext.Core.Domain;
using BlogCore.PostContext.Infrastructure;
using System.Threading.Tasks;

namespace BlogCore.PostContext.Migrator
{
    public static class PostContextSeeder
    {
        public static async Task Seed(PostDbContext dbContext)
        {
            // thangchung's user blog
            var blogId = new BlogId(IdHelper.GenerateId("34c96712-2cdf-4e79-9e2f-768cb68dd552"));
            var authorId = new AuthorId(IdHelper.GenerateId("4b5f26ce-df97-494c-b747-121d215847d8"));
            for (var i = 1; i <= 100; i++)
            {
                var post = Core.Domain.Post.CreateInstance(
                        blogId,
                        $"The title of post {i}",
                        $"The excerpt of post {i}",
                        $"The body of post {i}", authorId)
                    .AddComment("comment 1", authorId)
                    .AssignTag($"{i}");
                dbContext.Add(post);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}