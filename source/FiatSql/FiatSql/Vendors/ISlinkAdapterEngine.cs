namespace Slink.Vendors
{
    public interface ISlinkAdapterEngine
    {
        ISlinkSqlWriter CustomSqlWriter { get; }

        ISlinkTemplates CustomSqlTemplates { get; }

        
    }
}
