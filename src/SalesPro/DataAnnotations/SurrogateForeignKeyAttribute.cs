namespace SalesPro.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SurrogateForeignKeyAttribute : Attribute
    {
        public SurrogateForeignKeyAttribute(Type relatedType, string relatedTypeUniqeIndex, string sourceForeignKey)
        {
            RelatedType = relatedType;
            RelatedTypeUniqeIndex = relatedTypeUniqeIndex;
            SourceForeignKey = sourceForeignKey;
        }

        public Type RelatedType { get; set; }

        public string RelatedTypeUniqeIndex { get; set; }

        public string SourceForeignKey { get; set; }
    }
}