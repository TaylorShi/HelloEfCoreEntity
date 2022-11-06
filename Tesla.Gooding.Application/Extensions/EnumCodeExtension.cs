using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Tesla.Framework.Core;

namespace Tesla.Gooding.Application.Extensions
{
    internal static class EnumCodeExtension
    {
        public static void ThrowLanMessage(this Enum em, string message = "")
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                message = em.LDes();
            }

            throw new MessageException(message, em.GetHashCode());
        }

        public static void ThrowLanMessageParams(this Enum em, params object[] obj)
        {
            string text = em.LDes();
            if (obj != null && obj.Length != 0 && text.IndexOf("{0}") >= 0)
            {
                text = string.Format(text, obj);
            }

            em.ThrowMessage(text);
        }

        public static string LDes(this Enum em)
        {
            DescriptionAttribute attribute = em.GetAttribute<DescriptionAttribute>();
            if (attribute != null)
            {
                return attribute.Description;
            }

            return em.ToString();
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum em) where TAttribute : Attribute
        {
            FieldInfo field = em.GetType().GetField(em.ToString());
            if (field == null)
            {
                return null;
            }

            return field.GetCustomAttribute<TAttribute>();
        }
    }
}
