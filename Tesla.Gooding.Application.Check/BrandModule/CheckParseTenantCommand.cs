using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Gooding.Application.Check.BrandModule
{
    public class CheckParseTenantCommand : IRequest<long>
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        public string TenantId { get; private set; }

        public CheckParseTenantCommand(string tenantId)
        {
            TenantId = tenantId;
        }
    }
}
