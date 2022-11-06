using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Gooding.Application.CheckEvents;
using Tesla.Gooding.Infrastructure.Repositories;

namespace Tesla.Gooding.Application.Commands
{
    internal class ModifyBrandCommandHandler : IRequestHandler<ModifyBrandCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;
        private readonly IMediator _mediator;

        public ModifyBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository, IMediator mediator)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(ModifyBrandCommand request, CancellationToken cancellationToken)
        {
            var tenantId = await _mediator.Send(new CheckParseTenantCommand(request.TenantId));
            await _mediator.Publish(new CheckBrandInfoDomainEvent(request));
            Guid.TryParse(request.BrandId, out var brandId);
            var brand = await _brandRepository.GetAsync(brandId, cancellationToken);
            brand.Modify(tenantId, request.UserId, request.BrandName, request.BrandCode, request.BrandLogo);
            await _brandRepository.UpdateAsync(brand, cancellationToken);
            await _brandRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }
    }
}
