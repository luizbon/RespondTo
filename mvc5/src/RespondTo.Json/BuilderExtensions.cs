using RespondTo.Json;

namespace RespondTo
{
    public static class BuilderExtensions
    {
        public static Builder Json(this Builder builder)
        {
            Initializers.Register("json", new JsonInitializer());

            return builder;
        }
    }
}