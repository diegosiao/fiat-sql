namespace Slink
{
    public enum SlinkNamingPolicy
    {
        /// <summary>
        /// All text in lowercase
        /// <para>E.g.: myproperty, mycolumn</para>
        /// </summary>
        Lowercase,
        /// <summary>
        /// All text in lowercase with words separated by underscore
        /// <para>E.g.: my_property, my_column</para>
        /// </summary>
        UnderscoredLowerCase,
        /// <summary>
        /// 
        /// </summary>
        Camelcase,
        /// <summary>
        /// All text in uppercase
        /// <para>E.g.: MYPROPERTY, MYCOLUMN</para>
        /// </summary>
        Uppercase,
        /// <summary>
        /// All text in uppercase with words separated by underscore
        /// <para>E.g.: MY_PROPERTY, MY_COLUMN</para>
        /// </summary>
        UnderscoredUppercase,
    }
}
