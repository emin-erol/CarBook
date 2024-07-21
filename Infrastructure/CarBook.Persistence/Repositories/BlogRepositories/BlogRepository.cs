using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRespository
    {
        private readonly CarBookContext _context;
        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }
        
        public List<Blog> GetLast3BlogsWithAuthors()
        {
            var values = _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogId).Take(3).ToList();
            return values;
        }

        public List<Blog> GetBlogsWithAuthors()
        {
            var values = _context.Blogs.Include(x => x.Author).Include(y => y.Category).ToList();
            return values;
        }

        public List<Blog> GetBlogByAuthorId(int authorId)
        {
            var value = _context.Blogs.Include(x => x.Author).Where(y =>  y.BlogId == authorId).ToList();
            return value;
        }
    }
}
