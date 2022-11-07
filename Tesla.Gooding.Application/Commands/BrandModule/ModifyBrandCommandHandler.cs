using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Gooding.Application.Check.BrandModule;
using Tesla.Gooding.Infrastructure.Repositories;

namespace Tesla.Gooding.Application.Commands.BrandModule
{
    /// <summary>
    /// 修改品牌命令处理程序
    /// </summary>
    internal class ModifyBrandCommandHandler : IRequestHandler<ModifyBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMediator _mediator;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="brandRepository"></param>
        /// <param name="mediator"></param>
        public ModifyBrandCommandHandler(IBrandRepository brandRepository, IMediator mediator)
        {
            _brandRepository = brandRepository;
            _mediator = mediator;
        }

        /// <summary>
        /// 处理方法
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(ModifyBrandCommand request, CancellationToken cancellationToken)
        {
            var tenantId = await _mediator.Send(new CheckParseTenantCommand(request?.TenantId));
            var brand = await _mediator.Send(new CheckBrandModifyCommand(request));

            brand.Modify(tenantId, request.UserId, request.BrandName, request.BrandCode);
            _brandRepository.Update(brand);
            await _brandRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
