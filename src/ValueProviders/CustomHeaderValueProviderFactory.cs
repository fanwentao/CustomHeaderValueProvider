using System;
using System.Globalization;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

namespace ValueProviders
{
    public class CustomHeaderValueProviderFactory : ValueProviderFactory, IUriValueProviderFactory
    {
        private const string RequestLocalStorageKey = "{5C608C0D-CCD2-4DFA-93DF-96537E5C2A03}";

        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            if (actionContext == null) throw new ArgumentNullException(nameof(actionContext));

            object provider;
            if (!actionContext.Request.Properties.TryGetValue(RequestLocalStorageKey, out provider))
            {
                provider = new CustomHeaderValueProvider(actionContext.Request, CultureInfo.InvariantCulture);
                actionContext.Request.Properties[RequestLocalStorageKey] = provider;
            }
            return (IValueProvider)provider;
        }



    }
}
