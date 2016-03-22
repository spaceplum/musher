using System.Collections.Generic;
using RestSharp;

namespace Musher.EchoNest.Extensions
{
    internal static class RestRequestExtensions
    {
        public static void TryAddQueryParameter(this RestRequest source, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                source.AddQueryParameter(key, value);
            }
        }

        public static void TryAddQueryParameter(this RestRequest source, string key, List<string> values)
        {
            foreach (var value in values)
            {
                source.TryAddQueryParameter(key, value);
            }
        }

        public static void TryAddQueryParameter(this RestRequest source, string key, int? value)
        {
            if (!value.HasValue) return;

            source.AddQueryParameter(key, value.ToString());
        }
    }
}
