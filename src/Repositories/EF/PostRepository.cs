﻿using gamestoolkit.api.Models;
using Microsoft.EntityFrameworkCore;

namespace gamestoolkit.api.Repositories.EF
{
    public class PostRepository : IPostRepository
    {
        private GTKContext _context;
        public PostRepository(GTKContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePostAsync(Post newPost)
        {
            var entity = await _context.Posts.AddAsync(newPost);
            await _context.SaveChangesAsync();

            return entity.Entity.Id;
        }

        public async Task DeletePostAsync(Post postToDelete)
        {
            _context.Posts.Remove(postToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            return post;
        }

        public async Task UpdatePostAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
