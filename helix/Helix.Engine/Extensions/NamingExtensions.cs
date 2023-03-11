using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Helix.Engine.Extensions
{
    internal static class NamingExtensions
    {
        internal static string UnboxedName(this Type type, bool nullable = false)
        {
            switch (type.FullName)
            {
                case "System.Guid":
                    return $"Guid{(nullable ? "?" : string.Empty)}";
                case "System.String":
                    return $"string{(nullable ? "?" : string.Empty)}";
                case "System.Decimal":
                    return $"decimal{(nullable ? "?" : string.Empty)}";
                case "System.Int32":
                    return $"int{(nullable ? "?" : string.Empty)}";
                case "System.Boolean":
                    return $"bool{(nullable ? "?" : string.Empty)}";
                case "System.DateTime":
                    return $"DateTime{(nullable ? "?" : string.Empty)}";
                default:
                    return type.Name;
            }
        }
    }
}
