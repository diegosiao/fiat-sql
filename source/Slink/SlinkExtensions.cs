using System;
using System.Collections.Generic;
using System.Data;

namespace Slink
{
    public static class SlinkExtensions
    {
        /// <summary>
        /// Applys the specified or the global FiatNamingPolicy to the words provided.
        /// <para>As a convention, words can be separated by blank spaces in benefit of readbility, or need to be written in CamelCase format.</para>
        /// <para>That is important because this is the format expected to transform the original string applying any naming policy.</para>
        /// </summary>
        /// <param name="wordsToNamingPolicy"></param>
        public static string Np(this string wordsToNamingPolicy, SlinkNamingPolicy? namingPolicy = null)
        {
            var _namingPolicy = namingPolicy ?? Slink.Options?.NamingPolicy;

            if(_namingPolicy == null)
            {
                Console.WriteLine($"SLINK WARNING: Naming policy is not defined, assuming {SlinkNamingPolicy.Lowercase}. That can cause errors or unnecessary objects recreation. ");

            }

            return wordsToNamingPolicy;
        }

        public static object GetIdValue<T>(this T entity)
        {
            var idProp = typeof(T).GetProperty("Id");

            if (idProp == null)
                throw new SlinkMissingIdPropertyException(typeof(T));

            return idProp.GetValue(entity);
        }

        public static IEnumerable<FiatDbParameter> GetParameters(this Type type, SlinkConfigNamespace configNamespace, object entity = null)
        {
            var parameters = new List<FiatDbParameter>();

            foreach(var prop in type.GetProperties())
            {
                parameters.Add(new FiatDbParameter
                {
                    ParameterName = prop.Name,
                    PropertyInfo = prop,
                    Direction = ParameterDirection.Input,
                    Value = entity != null ? prop.GetValue(entity) : null
                });
            }

            return parameters;
        }
    }
}
