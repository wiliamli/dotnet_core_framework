using Jwell.Framework.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Jwell.Web.Controllers.Base
{   
    public class BaseApiController : ControllerBase
    {
        [HttpPost("StandardAction")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public StandardJsonResult StandardAction(Action action)
        {
            var result = new StandardJsonResult();
            result.StandardAction(action);
            return result;
        }

        [HttpPost("StandardAction<T>")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public StandardJsonResult<T> StandardAction<T>(Func<T> action)
        {
            var result = new StandardJsonResult<T>();
            result.StandardAction(() =>
            {
                result.Data = action();
            });
            return result;
        }
    }
}
