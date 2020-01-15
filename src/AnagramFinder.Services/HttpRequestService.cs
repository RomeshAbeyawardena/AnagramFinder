using AnagramFinder.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramFinder.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        public Uri GenerateQueryString(Uri baseUrl, params KeyValuePair<string, object>[] parameters)
        {
            var queryStringParameters = new StringBuilder("?");
            var index = 0;
            foreach(var (key, value) in parameters)
            {
                var isLast = index == parameters.Length  - 1;
                queryStringParameters.AppendFormat("{0}={1}{2}", key, value, isLast ? string.Empty : "&");
                index++;
            }

            if(Uri.TryCreate(baseUrl, new Uri(queryStringParameters.ToString()), out var newUri))
                return newUri;

            return baseUrl;
        }
    }
}
