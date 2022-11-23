using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Tesla.Practing.Domain.AggregatesModel.BlogAggregates;

namespace Tasla.Querring.Console.Extensions
{
    internal static class SerializeExtensions
    {
        public static void JsonPrint(this object o)
        {
            System.Console.WriteLine(JsonSerializer.Serialize(o, options: new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
