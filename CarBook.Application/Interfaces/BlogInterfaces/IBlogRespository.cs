using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRespository
    {
        List<Blog> GetLast3BlogsWithAuthors();
        List<Blog> GetBlogsWithAuthors();
        List<Blog> GetBlogByAuthorId(int authorId);
    }
}
