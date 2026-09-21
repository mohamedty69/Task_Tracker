using Application;
using Application.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TaskRepo : GenericRepo<Domain.Entities.Task>, ITaskRepo
    {
        private readonly AppDbContext _context;
        public TaskRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
