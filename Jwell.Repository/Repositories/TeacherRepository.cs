using Jwell.Domian.Entities;
using Jwell.Modules.EFCore.Repositories;
using Jwell.Repository.Context;

namespace Jwell.Repository.Repositories
{
    public class TeacherRepository : EfCoreRepository<JwellDbContext, Teacher, int>, ITeacherRepository
    {
        public TeacherRepository(JwellDbContext dbContext) : base(dbContext)
        {
        }
    }
}
