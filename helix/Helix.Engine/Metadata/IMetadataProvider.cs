using Helix.Common;

namespace Helix.Engine.Metadata
{
    internal interface IMetadataProvider
    {
        DatabaseVendor DatabaseVendor { get; }

        string DatabaseName { get; }

        IEnumerable<ITableDescriptor> TableDescriptors { get; }

        Task LoadDescriptorsAsync();
    }
}
