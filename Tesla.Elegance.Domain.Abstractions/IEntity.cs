using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Elegance.Domain.Abstractions
{
    /// <summary>
    /// 实体泛型接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
