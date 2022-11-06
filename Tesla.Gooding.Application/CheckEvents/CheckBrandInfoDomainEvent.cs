
using Tesla.Framework.Domain.Abstractions;
using Tesla.Gooding.DataContract.BrandModule.VO;

namespace Tesla.Gooding.Application.CheckEvents
{
    internal class CheckBrandInfoDomainEvent : IDomainEvent
    {
        public CreateBrandVo BrandVo { get; private set; }

        public CheckBrandInfoDomainEvent(CreateBrandVo brandVo)
        {
            BrandVo = brandVo;
        }
    }
}
