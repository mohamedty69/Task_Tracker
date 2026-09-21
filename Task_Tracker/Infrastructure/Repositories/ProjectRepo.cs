using Application;
using Application.Interfaces.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ProjectRepo : GenericRepo<Project>, IProjectRepo
    {
        private readonly AppDbContext _context;

        public ProjectRepo(AppDbContext context): base(context)
        {
            _context = context;            
        }
    }
}
