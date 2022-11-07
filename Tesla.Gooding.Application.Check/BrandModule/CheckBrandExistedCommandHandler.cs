using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Framework.Core.Extensions;
using Tesla.Gooding.DataContract.Common;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;
using Tesla.Gooding.Infrastructure.Contexts;

namespace Tesla.Gooding.Application.Check.BrandModule
{
    internal class CheckBrandExistedCommandHandler : IRequestHandler<CheckBrandExistedCommand, Brand>
    {
        private readonly GoodingSlaveContext _goodingSlaveContext;

        public CheckBrandExistedCommandHandler(GoodingSlaveContext goodingSlaveContext)
        {
            _goodingSlaveContext = goodingSlaveContext;
        }

        public async Task<Brand> Handle(CheckBrandExistedCommand request, CancellationToken cancellationToken)
        {
            Guid brandId = default;
            if (string.IsNullOrEmpty(request.BrandVo.BrandId) ||
                !Guid.TryParse(request.BrandVo.BrandId, out brandId))
            {
                // 品牌ID缺失
                MessageCode.ErrBrandIdNull.ThrowLanMessage();
            }

            var brand = await _goodingSlaveContext.Brands.Where(x => x.Id == brandId).FirstOrDefaultAsync(cancellationToken);
            if (brand == null)
            {
                // 品牌不存在
                MessageCode.ErrBrandNotExist.ThrowLanMessage();
            }

            return brand;
        }
    }
}
