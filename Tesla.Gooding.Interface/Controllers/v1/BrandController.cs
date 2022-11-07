using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tesla.Framework.DataContract.Abstractions.QueryModule.DTO;
using Tesla.Gooding.Application.Commands.BrandModule;
using Tesla.Gooding.Application.Queries;
using Tesla.Gooding.DataContract.BrandModule.DTO;

namespace Tesla.Gooding.Interface.Controllers.v1
{
    /// <summary>
    /// 品牌服务
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mediator"></param>
        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 创建品牌
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Create([FromBody]CreateBrandCommand cmd)
        {
            return await _mediator.Send(cmd, HttpContext.RequestAborted);
        }

        /// <summary>
        /// 删除品牌
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Delete([FromBody]DeleteBrandCommand cmd)
        {
            return await _mediator.Send(cmd, HttpContext.RequestAborted);
        }

        /// <summary>
        /// 恢复品牌
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Recovery([FromBody]RecoveryBrandCommand cmd)
        {
            return await _mediator.Send(cmd, HttpContext.RequestAborted);
        }

        /// <summary>
        /// 清空品牌
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Clear([FromBody]ClearBrandCommand cmd)
        {
            return await _mediator.Send(cmd, HttpContext.RequestAborted); ;
        }

        /// <summary>
        /// 修改品牌
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Modify([FromBody]ModifyBrandCommand cmd)
        {
            return await _mediator.Send(cmd, HttpContext.RequestAborted);
        }

        /// <summary>
        /// 查询品牌
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedList<BrandDto>> Query([FromQuery]BrandQuery cmd)
        {
            return await _mediator.Send(cmd, HttpContext.RequestAborted);
        }

        /// <summary>
        /// 搜索品牌
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PagedList<BrandDto>> Search([FromBody]BrandSearch cmd)
        {
            return await _mediator.Send(cmd, HttpContext.RequestAborted);
        }
    }
}
