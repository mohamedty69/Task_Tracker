using Application.Interfaces.IRepositories;
using Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        public ITaskRepo Tasks { get; }
        public IProjectRepo Projects { get; }
        public ICommentRepo Comments { get; } 
        public Task SaveChangesAsync();
    }
}
