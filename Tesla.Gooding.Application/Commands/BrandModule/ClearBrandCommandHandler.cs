using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Framework.Infrastructure.Core.Extensions;
using Tesla.Gooding.Application.Check.BrandModule;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;
using Tesla.Gooding.Infrastructure.Contexts;
using Tesla.Gooding.Infrastructure.Repositories;

namespace Tesla.Gooding.Application.Commands.BrandModule
{
    internal class ClearBrandCommandHandler : IRequestHandler<ClearBrandCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IBrandRepository _brandRepository;
        private readonly GoodingSlaveContext _goodingSlaveContext;

        public ClearBrandCommandHandler(IMediator mediator, IBrandRepository brandRepository, GoodingSlaveContext goodingSlaveContext)
        {
            _mediator = mediator;
            _brandRepository = brandRepository;
            _goodingSlaveContext = goodingSlaveContext;
        }

        public async Task<bool> Handle(ClearBrandCommand request, CancellationToken cancellationToken)
        {
            var tenantId = await _mediator.Send(new CheckParseTenantCommand(request?.TenantId));

            IQueryable<Brand> query = _goodingSlaveContext.Brands
                .WhereIf(tenantId > 0, x => x.TenantId == tenantId);
            var brandIds = await query.Select(x => x.Id).ToListAsync();

            if (brandIds != null && brandIds.Any())
            {
                brandIds.ForEach(x => _brandRepository.Delete(x));
                await _brandRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }
            
            return true;
        }
    }
}
