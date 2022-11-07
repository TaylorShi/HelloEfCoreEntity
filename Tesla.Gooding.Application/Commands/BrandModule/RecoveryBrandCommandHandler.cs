using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Gooding.Application.Check.BrandModule;
using Tesla.Gooding.Infrastructure.Repositories;

namespace Tesla.Gooding.Application.Commands.BrandModule
{
    internal class RecoveryBrandCommandHandler : IRequestHandler<RecoveryBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMediator _mediator;

        public RecoveryBrandCommandHandler(IBrandRepository brandRepository, IMediator mediator)
        {
            _brandRepository = brandRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(RecoveryBrandCommand request, CancellationToken cancellationToken)
        {
            var tenantId = await _mediator.Send(new CheckParseTenantCommand(request?.TenantId));
            var brand = await _mediator.Send(new CheckBrandExistedCommand(request));
            if (brand.IsDeleted)
            {
                brand.Recovery(tenantId, request.UserId);
                _brandRepository.Update(brand);
                await _brandRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }
            return true;
        }
    }
}
