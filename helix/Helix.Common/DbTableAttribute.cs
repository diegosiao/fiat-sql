namespace Helix.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DbTableAttribute : Attribute
    {
        public string TableName { get; set; }

        public string PrimaryKey { get; set; }

        public DbTableAttribute(string tableName, string primaryKey)
        {
            TableName = tableName;
            PrimaryKey = primaryKey;
        }
    }
}
