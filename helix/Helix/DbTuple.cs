namespace Helix.Core
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DbTuple
    {
        protected bool StatisticsOn { get; set; }

        internal static string InsertTemplate { get; set; }

        protected static string UpdateTemplate { get; set; }

        protected static string DeleteTemplate { get; set; }

        protected static string SelectTemplate { get; set; }

        protected DbTuple(
            string insertTemplate, 
            string updateTemplate,
            string selectTemplate,
            string deleteTemplate) {
            InsertTemplate ??= insertTemplate;
            UpdateTemplate ??= updateTemplate;
            SelectTemplate ??= selectTemplate;
            DeleteTemplate ??= deleteTemplate;
        }

        internal virtual bool BeforeInsert()
        {
            return true;
        }

        internal virtual bool AfterInsert()
        {

            return true;
        }

        internal string GetInsertTemplate()
        {
            return InsertTemplate;
        }
    }
}
