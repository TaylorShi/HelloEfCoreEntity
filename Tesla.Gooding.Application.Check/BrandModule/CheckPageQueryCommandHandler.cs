using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Framework.Core.Extensions;
using Tesla.Gooding.DataContract.Common;

namespace Tesla.Gooding.Application.Check.BrandModule
{
    internal class CheckPageQueryCommandHandler : IRequestHandler<CheckPageQueryCommand, bool>
    {
        public async Task<bool> Handle(CheckPageQueryCommand request, CancellationToken cancellationToken)
        {
            if (request.PageVo.PageIndex <= 0)
            {
                // 分页条件不合规(查询起始不得低于{0})
                MessageCode.ErrPageIndexLowerMin.ThrowLanMessageParams(1);
            }

            if (request.PageVo.PageSize <= 0)
            {
                // 分页条件不合规(查询不得低于{0}条)
                MessageCode.ErrPageSizeLowerMin.ThrowLanMessageParams(1);
            }

            if (request.PageVo.PageSize > 200)
            {
                // 分页条件不合规(查询不得超过{0}条)
                MessageCode.ErrPageSizeOverMax.ThrowLanMessageParams(200);
            }

            return await Task.FromResult(true);
        }
    }
}
