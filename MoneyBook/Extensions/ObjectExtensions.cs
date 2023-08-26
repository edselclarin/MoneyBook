using System.Reflection;
using System.Text;

namespace MoneyBook.Extensions
{
    public static class ObjectExtensions
    {
        public static string GetHash<T>(this T obj)
        {
            var sb = new StringBuilder();
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                var val = prop.GetValue(obj);
                sb.Append(val != null ? val.ToString() : "(null)");
            }
            return sb.ToString();
        }
    }
}
