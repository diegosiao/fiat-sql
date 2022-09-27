using System;

namespace Slink.Mapping
{
    /// <summary>
    /// A fiat table dotnet entity needs to strictly represent the database table and its columns.
    /// <para>There is no abstraction to relations. E.g. arrays representing a One to Many relation.</para>
    /// <para>Mappings and relation abstractions are done by implementing FiatSql.IQuery.</para>
    /// </summary>
    public class SlinkTableAttribute : Attribute
    {
        internal string Name;

        internal string PrimaryKey;

        internal long CacheTimespan;

        /// <summary>
        /// Database table mapping and options
        /// </summary>
        /// <param name="name">Table name</param>
        /// <param name="primaryKey">Column name of the primary key. The class needs to have a property 'Id' with a compatible .NET type. </param>
        /// <param name="cacheTimespan">
        /// Time in seconds a cache should be considered valid.
        /// <para>You can always invalidate or ignore cache per entity or globaly.</para>
        /// </param>
        public SlinkTableAttribute(string name, string primaryKey, long cacheTimespan = 0)
        {
            Name = name;
            PrimaryKey = primaryKey;
            CacheTimespan = cacheTimespan;
        }
    }
}
