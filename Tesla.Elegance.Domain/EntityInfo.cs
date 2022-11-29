using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tesla.Elegance.Domain.Abstractions;

namespace Tesla.Elegance.Domain
{
    public class EntityInfo
    {
        public (Assembly Assembly, IEnumerable<Type> Types) EntitiesInfo => (GetType().Assembly, GetEntityTypes(GetType().Assembly));
        
        private IEnumerable<Type> GetEntityTypes(Assembly assembly)
        {
            // 获取当前程序集下所有的实现了IEntity的实体类
            var entities = assembly.GetTypes()
            .Where(m =>
                m.FullName != null && 
                Array.Exists
                (
                    m.GetInterfaces(), 
                    t => t.IsGenericType && 
                    t.GetGenericTypeDefinition() == typeof(IEntity<>)
                ) &&
                !m.IsAbstract && 
                !m.IsInterface
            ).ToArray();

            return entities;
        }
    }
}
