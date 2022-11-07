using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Framework.Core.Extensions;
using Tesla.Gooding.DataContract.Common;

namespace Tesla.Gooding.Application.Check.BrandModule
{
    internal class CheckParseTenantCommandHandler : IRequestHandler<CheckParseTenantCommand, long>
    {
        public async Task<long> Handle(CheckParseTenantCommand request, CancellationToken cancellationToken)
        {
            long tenantId = 0;

            if (string.IsNullOrEmpty(request.TenantId) ||
                !long.TryParse(request.TenantId, out tenantId))
            {
                // 商户信息缺失
                MessageCode.ErrTenantIdNull.ThrowLanMessage();
            }

            return await Task.FromResult(tenantId);
        }
    }
}
