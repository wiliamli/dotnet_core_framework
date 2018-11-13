using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Jwell.Framework.Interceptors
{
    public class TransactionAttribute : AbstractInterceptorAttribute
    {
        [FromContainer]
        public  DbContext DbContext { get; set; }  

        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            using (var trans = DbContext.Database.BeginTransaction())
            {
                try
                {
                    await next(context);
                    DbContext.SaveChanges();
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }
}
