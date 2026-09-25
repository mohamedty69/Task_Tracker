using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Infrastructure.Repositories;


namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly AppDbContext _context;

        public ITaskRepo Tasks {  get; }

        public IProjectRepo Projects {  get; }
        public ICommentRepo Comments { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Projects = new ProjectRepo(context);
            Tasks = new TaskRepo(context);
            Comments = new CommentRepo(context);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
