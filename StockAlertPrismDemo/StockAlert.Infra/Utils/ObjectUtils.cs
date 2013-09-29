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
        public static string toStringReflect(this Object obj)
        {
            // Extract name-value pairs for all readable public properties.
            var props = from prop in obj.GetType().GetProperties(System.Reflection.BindingFlags.NonPublic)
                        where prop.CanRead
                        orderby prop.Name
                        select new { Name = prop.Name, Value = prop.GetValue(obj) };

            // Compose string in the form name=value name=value ....
            StringBuilder sb = new StringBuilder();
            foreach (var prop in props)
            {
                sb.AppendFormat("{0}={1} ", prop.Name, prop.Value);
            }
            return sb.ToString();
        }
    }
}
