using Jwell.Domain.Entities;
using Jwell.Modules.EFCore.Repositories;
using Jwell.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Jwell.Repository.Repositories
{
    public class StudentRepository : EfCoreRepository<JwellDbContext, Student, int>, IStudentRepository
    {
        public StudentRepository(JwellDbContext dbContext) : base(dbContext)
        {
        }
    }
}
