namespace Helix.Common
{
    public class ReferencesAttribute : Attribute
    {
        public Type ReferenceEntityType { get; private set; }

        public ReferencesAttribute(Type referenceEntityType) 
        { 
            ReferenceEntityType = referenceEntityType;
        }
    }
}
