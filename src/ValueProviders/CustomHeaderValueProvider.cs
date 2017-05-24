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
        private const string CustomHeaderPrefix = "X-";
        public CustomHeaderValueProvider(HttpRequestMessage request, CultureInfo culture)
            : base(GetHeadersValues(request.Headers), culture)
        {

        }
        internal static Dictionary<string, object> GetHeadersValues(HttpRequestHeaders headers)
        {
            var dic = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            foreach (var header in headers.Where(pair => pair.Key.StartsWith(CustomHeaderPrefix, StringComparison.OrdinalIgnoreCase)))
            {
                var key = header.Key.Substring(CustomHeaderPrefix.Length).Replace("-", string.Empty);
                dic[key] = header.Value;
            }
            return dic;
        }
    }
}
