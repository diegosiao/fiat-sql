namespace FiatSql.Vendors
{
    public interface IFiatTemplates
    {
        /// <summary>
        /// Placeholders:
        /// <para>_#schema#_</para>
        /// <para>_#hash#_</para>
        /// <para>_#name#_</para>
        /// <para>_#parameters#_</para>
        /// <para>_#body#_</para>
        /// </summary>
        string ProcedureTemplate { get; } 
    }
}
