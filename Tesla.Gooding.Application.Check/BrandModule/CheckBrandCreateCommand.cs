
using MediatR;
using Tesla.Gooding.DataContract.BrandModule.VO;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;

namespace Tesla.Gooding.Application.Check.BrandModule
{
    public class CheckBrandCreateCommand : IRequest<Brand>
    {
        public CreateBrandVo BrandVo { get; private set; }

        public CheckBrandCreateCommand(CreateBrandVo brandVo)
        {
            BrandVo = brandVo;
        }
    }
}
