using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Gooding.Application.Check.BrandModule;
using Tesla.Gooding.Infrastructure.Repositories;

namespace Tesla.Gooding.Application.Commands.BrandModule
{
    /// <summary>
    /// 创建品牌命令处理程序
    /// </summary>
    internal class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMediator _mediator;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="brandRepository"></param>
        /// <param name="mediator"></param>
        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMediator mediator)
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
        public async Task<bool> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var tenantId = await _mediator.Send(new CheckParseTenantCommand(request?.TenantId));
            var brand = await _mediator.Send(new CheckBrandCreateCommand(request));

            brand.Create(tenantId, request.UserId);
            _brandRepository.Add(brand);
            await _brandRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
