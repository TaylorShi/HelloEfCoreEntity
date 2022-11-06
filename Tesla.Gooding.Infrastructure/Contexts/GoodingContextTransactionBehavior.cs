using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.Infrastructure.Core.Behaviors;

namespace Tesla.Gooding.Infrastructure.Contexts
{
    /// <summary>
    /// 领域事务行为管理类
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class GoodingContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<GoodingMasterContext, TRequest, TResponse>
    {
        public GoodingContextTransactionBehavior(GoodingMasterContext dbContext, ILogger<GoodingContextTransactionBehavior<TRequest, TResponse>> logger) : base(dbContext, logger)
        {
        }
    }
}
