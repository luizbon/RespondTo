using RespondTo.Xml;

namespace RespondTo
{
    public static class BuilderExtensions
    {
        public static Builder Xml(this Builder builder)
        {
            Initializers.Register("xml", new XmlInitializer());

            return builder;
        }
    }
}