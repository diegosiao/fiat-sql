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
        public static string Np(this string wordsToNamingPolicy, FiatNamingPolicy? namingPolicy = null)
        {
            var _namingPolicy = namingPolicy ?? Slink.Options.NamingPolicy;

            return wordsToNamingPolicy;
        }

        public static object GetIdValue<T>(this T entity)
        {
            var idProp = typeof(T).GetProperty("Id");

            if (idProp == null)
                throw new SlinkMissingIdPropertyException(typeof(T));

            return idProp.GetValue(entity);
        }
    }
}
