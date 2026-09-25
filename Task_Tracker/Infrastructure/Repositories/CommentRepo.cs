using Application;
using Application.Interfaces.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CommentRepo : GenericRepo<Comment> , ICommentRepo
    {
        private readonly AppDbContext _context;

        public CommentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
