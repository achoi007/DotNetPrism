using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Utils
{
    public static class ObjectUtils
    {
        /// <summary>
        /// Using reflection to generate a string from object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToStringReflect(this Object obj)
        {
            // Extract name-value pairs for all readable public non-indexed properties.
            var props = from prop in obj.GetType().GetProperties(System.Reflection.BindingFlags.Public)
                        where prop.CanRead && prop.GetIndexParameters().Length == 0
                        orderby prop.Name
                        select new { Name = prop.Name, Value = prop.GetValue(obj) };

            // Compose string in the form name=value name=value ....
            return props.Aggregate(new StringBuilder(),
                (sb, p) => sb.AppendFormat("{0}={1} ", p.Name, p.Value),
                sb => sb.ToString());
        }
    }
}
