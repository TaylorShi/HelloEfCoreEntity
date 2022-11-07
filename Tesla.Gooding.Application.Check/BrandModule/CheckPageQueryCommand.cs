using MediatR;
using Tesla.Framework.DataContract.Abstractions.QueryModule.VO;

namespace Tesla.Gooding.Application.Check.BrandModule
{
    public class CheckPageQueryCommand : IRequest<bool>
    {
        public PageVo PageVo { get; private set; }

        public CheckPageQueryCommand(PageVo pageVo)
        {
            PageVo = pageVo;
        }
    }
}
