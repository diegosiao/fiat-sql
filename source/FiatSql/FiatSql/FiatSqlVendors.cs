namespace FiatSql
{
    /// <summary>
    /// The supported vendors and versions means that the same pseudo SQL generated outputs ran successfully in all combinations.
    /// <para>To see all operations and environment used on tests visit <a href="https://github.com/diegosiao/fiat-sql"/></para>
    /// </summary>
    public enum FiatSqlVendors
    {
        Undefined,

        /// <summary>
        /// You can implement your customized ISlinkSqlWriter and ISlinkSqlTemplates to support a different database or change default behaviour.
        /// <para>But remember: "With great power comes great responsibility".</para>
        /// </summary>
        Custom,

        /// <summary>
        /// <para>Versions: 5.1, 5.5, 5.6, 5.7</para>
        /// </summary>
        MySQL = 13005,
        
        /// <summary>
        /// <para>v8.0</para>
        /// </summary>
        MySQL2 = 13008,

        /// <summary>
        /// <para>Versions: ?</para>
        /// </summary>
        MariaDB = 13201,

        /// <summary>
        /// <para>Versions: 10c, 12c</para>
        /// </summary>
        Oracle = 15001,
        
        /// <summary>
        /// <para>Versions: 11, 12, 13, 14</para>
        /// </summary>
        Postgres = 16001,
        
        /// <summary>
        /// <para>Versions: 2012, 2014, 2016, 2017</para>
        /// </summary>
        SqlServer = 19001
    }
}