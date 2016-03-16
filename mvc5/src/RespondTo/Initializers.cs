using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;

namespace RespondTo
{
    public static class Initializers
    {
        private static readonly IDictionary<string, IInitializer> _initializers;

        static Initializers()
        {
            _initializers = new Dictionary<string, IInitializer>();
        }

        public static IEnumerable<IInitializer> All => _initializers.Select(x => x.Value);

        public static void Register(string name, IInitializer initializer)
        {
            if (_initializers.ContainsKey(name))
                _initializers.Remove(name);
            _initializers.Add(name, initializer);
        }

        public static ActionResult Execute(string extension, object model)
        {
            return _initializers[extension].Execute(model);
        }

        public static IInitializer FindFormatter(NameValueCollection headers)
        {
            return All.FirstOrDefault(initializer => initializer.Accept(headers));
        }
    }
}