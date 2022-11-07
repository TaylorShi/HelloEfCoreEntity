using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Framework.Core.Extensions;
using Tesla.Gooding.DataContract.Common;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;

namespace Tesla.Gooding.Application.Check.BrandModule
{
    internal class CheckBrandCreateCommandHandler : IRequestHandler<CheckBrandCreateCommand, Brand>
    {
        private readonly IMapper _mapper;

        public CheckBrandCreateCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Brand> Handle(CheckBrandCreateCommand request, CancellationToken cancellationToken)
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

            var brand = _mapper.Map<Brand>(request.BrandVo);
            if (brand == null)
            {
                // 格式错误
                MessageCode.ErrConvertNull.ThrowLanMessage();
            }

            return await Task.FromResult(brand);
        }
    }
}
