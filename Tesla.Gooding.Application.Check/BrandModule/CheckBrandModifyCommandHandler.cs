using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Framework.Core.Extensions;
using Tesla.Gooding.DataContract.Common;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;
using Tesla.Gooding.Infrastructure.Repositories;

namespace Tesla.Gooding.Application.Check.BrandModule
{
    internal class CheckBrandModifyCommandHandler : IRequestHandler<CheckBrandModifyCommand, Brand>
    {
        private readonly IBrandRepository _brandRepository;

        public CheckBrandModifyCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Brand> Handle(CheckBrandModifyCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.BrandVo == null)
            {
                // 缺少参数
                MessageCode.ErrKeyIsNull.ThrowLanMessage();
            }

            if (string.IsNullOrEmpty(request.BrandVo.BrandName))
            {
                // 品牌名称缺失
                MessageCode.ErrBrandNameNull.ThrowLanMessage();
            }

            if (string.IsNullOrEmpty(request.BrandVo.BrandCode))
            {
                // 品牌编码缺失
                MessageCode.ErrBrandCodeNull.ThrowLanMessage();
            }

            Guid brandId = default;
            if (string.IsNullOrEmpty(request.BrandVo.BrandId) ||
                !Guid.TryParse(request.BrandVo.BrandId, out brandId))
            {
                // 品牌ID缺失
                MessageCode.ErrBrandIdNull.ThrowLanMessage();
            }

            var brand = await _brandRepository.GetAsync(brandId, cancellationToken);
            if (brand == null)
            {
                // 品牌不存在
                MessageCode.ErrBrandNotExist.ThrowLanMessage();
            }

            return brand;
        }
    }
}
