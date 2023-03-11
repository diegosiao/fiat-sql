namespace Helix.Engine.Metadata
{
    internal interface IColumnDescriptor
    {
        string Schema { get; }

        string Table { get; }

        string Name { get; }

        int OrdinalPosition { get; }

        int? Length { get; }

        bool IsNullable { get; }

        bool IsPrimaryKey { get; }

        bool HasDefault { get; }

        string? Comment { get; }

        IDatabaseTypeDescriptor TypeDescriptor { get; }
    }
}
