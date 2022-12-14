using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Tesla.Gooding.DataContract.BrandModule.DTO;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;
using Tesla.Gooding.Infrastructure.Contexts;
using MediatR;
using AutoMapper;
using Tesla.Framework.Infrastructure.Core.Extensions;
using Tesla.Gooding.Application.Check.BrandModule;
using Tesla.Framework.DataContract.Abstractions.QueryModule.DTO;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using AutoMapper.QueryableExtensions;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;
using Microsoft.EntityFrameworkCore;

namespace Tesla.Gooding.Application.Queries
{
    internal class BrandSearchHandler : IRequestHandler<BrandSearch, PagedList<BrandDto>>
    {
        private readonly GoodingSlaveContext _goodingSlaveContext;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMediator _mediator;

        public BrandSearchHandler(GoodingSlaveContext goodingSlaveContext, IConfigurationProvider configurationProvider, IMediator mediator)
        {
            this._goodingSlaveContext = goodingSlaveContext;
            this._configurationProvider = configurationProvider;
            this._mediator = mediator;
        }

        public async Task<PagedList<BrandDto>> Handle(BrandSearch request, CancellationToken cancellationToken)
        {
            var tenantId = await _mediator.Send(new CheckParseTenantCommand(request.TenantId));
            await _mediator.Send(new CheckPageQueryCommand(request));
            FilterParams(request, out var brandIds, out var brandNameList, out var brandCodeList);

            //var list = from b in _goodingSlaveContext.Brands
            //           join bi in _goodingSlaveContext.BrandImages on b.Code equals bi.Code
            //           join bu in _goodingSlaveContext.BrandUrls on b.Code equals bu.Code
            //           select new
            //           {
            //               Name = b.Name,
            //               Code = b.Code,
            //               ImageUrl = bi.Url,
            //               Url = bu.Url
            //           };

            //var paged = list.Skip(request.PageIndex - 1).Take(request.PageSize).ProjectTo<BrandDto>(_configurationProvider).ToListAsync(cancellationToken);

            IQueryable <Brand> query = _goodingSlaveContext.Brands
                .WhereIf(tenantId > 0, x => x.TenantId == tenantId)
                .WhereIf(brandIds != null && brandIds.Any(), x => brandIds.Contains(x.Id))
                .WhereIf(brandCodeList != null && brandCodeList.Any(), x => brandCodeList.Contains(x.Code))
                .WhereIf(brandNameList != null && brandNameList.Any(), x => brandNameList.Contains(x.Name))
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.CreateOn);

            return await query.Paged<Brand, BrandDto>(request.PageIndex, request.PageSize, _configurationProvider, cancellationToken);
        }

        private void FilterParams(BrandSearch request, out List<Guid> brandIds, out List<string> brandNameList, out List<string> brandCodeList)
        {
            brandIds = request.BrandIdList
            ?.Where(x => !string.IsNullOrEmpty(x) && Guid.TryParse(x, out var brandIdVo) && brandIdVo != default)
            ?.Select(x => Guid.Parse(x))?.ToList();
            brandNameList = request?.BrandNameList?.Where(x => !string.IsNullOrEmpty(x) && !string.IsNullOrWhiteSpace(x))?.Distinct()?.ToList();
            brandCodeList = request?.BrandCodeList?.Where(x => !string.IsNullOrEmpty(x) && !string.IsNullOrWhiteSpace(x))?.Distinct()?.ToList();
        }
    }
}
