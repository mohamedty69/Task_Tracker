using Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.IRepositories
{
    public interface ITaskRepo : IGenericRepo<Domain.Entities.Task>
    {
    }
}
