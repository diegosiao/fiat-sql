namespace Helix.Engine.Metadata
{
    internal interface ITableDescriptor
    {
        public string Schema { get; }

        public string Name { get; }

        public IDatabaseTypeDescriptor PrimaryKeyDescriptor { get; }

        public IEnumerable<IColumnDescriptor> Columns { get; }
    }
}
