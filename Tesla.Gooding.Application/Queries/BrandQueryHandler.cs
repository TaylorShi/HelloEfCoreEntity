using AutoMapper;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Framework.DataContract.Abstractions.QueryModule.DTO;
using Tesla.Framework.Infrastructure.Core.Extensions;
using Tesla.Gooding.Application.Check.BrandModule;
using Tesla.Gooding.DataContract.BrandModule.DTO;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;
using Tesla.Gooding.Infrastructure.Contexts;

namespace Tesla.Gooding.Application.Queries
{
    internal class BrandQueryHandler : IRequestHandler<BrandQuery, PagedList<BrandDto>>
    {
        private readonly GoodingSlaveContext _goodingSlaveContext;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMediator _mediator;

        public BrandQueryHandler(GoodingSlaveContext goodingSlaveContext, IConfigurationProvider configurationProvider, IMediator mediator)
        {
            this._goodingSlaveContext = goodingSlaveContext;
            this._configurationProvider = configurationProvider;
            this._mediator = mediator;
        }

        public async Task<PagedList<BrandDto>> Handle(BrandQuery request, CancellationToken cancellationToken)
        {
            var tenantId = await _mediator.Send(new CheckParseTenantCommand(request.TenantId));
            await _mediator.Send(new CheckPageQueryCommand(request));
            FilterParams(request, out var brandId, out var brandName, out var brandCode);

            IQueryable<Brand> query = _goodingSlaveContext.Brands
                .WhereIf(tenantId > 0, x => x.TenantId == tenantId)
                .WhereIf(brandId != null, x => x.Id == brandId)
                .WhereIf(!string.IsNullOrEmpty(brandCode), x => x.Code == brandCode)
                .WhereIf(!string.IsNullOrEmpty(brandName), x => x.Name.Contains(brandName))
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.CreateOn);

            return await query.Paged<Brand, BrandDto>(request.PageIndex, request.PageSize, _configurationProvider, cancellationToken);
        }

        private void FilterParams(BrandQuery request, out Guid? brandId, out string brandName, out string brandCode)
        {
            brandId = null;
            if (!string.IsNullOrEmpty(request.BrandId) && Guid.TryParse(request.BrandId, out var brandIdVo) && brandIdVo != default)
            {
                brandId = brandIdVo;
            }
            brandName = request.BrandName;
            brandCode = request.BrandCode;
        }
    }
}
