using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tesla.Gooding.Interface.Controllers.v0
{
    /// <summary>
    /// 默认服务
    /// </summary>
    [Route("/")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// 默认地址
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
