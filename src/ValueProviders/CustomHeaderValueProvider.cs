using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;

namespace ValueProviders
{
    public class CustomHeaderValueProvider : NameValuePairsValueProvider
    {
        public CustomHeaderValueProvider(HttpRequestMessage request, CultureInfo culture)
            : base(GetHeadersValues(request.Headers), culture)
        {

        }
        internal static Dictionary<string, object> GetHeadersValues(HttpRequestHeaders headers)
        {
            return headers.ToDictionary(pair => pair.Key, pair => (object)pair.Value.ToList());
        }

        public override ValueProviderResult GetValue(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            key = "X-" + ParseParameterName(key);

            return base.GetValue(key);
        }

        internal static string ParseParameterName(string name)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsUpper(name[i]) && i != 0)
                {
                    sb.Append('-');
                }
                sb.Append(name[i]);
            }
            return sb.ToString();
        }
    }
}
